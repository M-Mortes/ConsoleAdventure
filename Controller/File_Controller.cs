using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleAdventure.Room_Parts;
using ConsoleAdventure.Entitys;

namespace ConsoleAdventure.Controller
{
    internal class File_Controller
    {
        private Player _player;
        public File_Controller(Player player)
        {
            _player = player;
        }
        private void Write_File(List<string> text, string file_name)
        {
            string file = file_name + ".txt";
            if (!File.Exists(file))
            {
                using StreamWriter _sw = File.CreateText(file);
            }
            using StreamWriter sw = new(file, false);
            foreach (string line in text)
            {
                sw.WriteLine(line);
            }
        }

        private List<string> Read_File(string file)
        {
            List<string> lines = new();
            string fileName = file + ".txt";

            if (!File.Exists(fileName))
            {
                return [];
            }

            using StreamReader sr = new(fileName);
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }

        public List<List<string>> Get_Map_List()
        {
            List<string> map_file = Read_File("map");
            List<List<string>> map = new();
            for (int i = 0; i < map_file.Count; i += 4)
            {
                List<string> map_part =
                [
                    Get_Map_Part(map_file, i),
                    Get_Map_Part(map_file, i + 1),
                    Get_Map_Part(map_file, i + 2),
                    Get_Map_Part(map_file, i + 3),
                ];
                map.Add(map_part);
            }
            return map;
        }
        private string Get_Map_Part(List<string> map_file, int index)
        {
            int counter = 1;
            string map_part = "";
            foreach (char item in map_file[index])
            {
                if (counter % 4 == 0)
                    break;
                map_part += item;
                counter++;
            }
            return map_part;
        }

        public void write_Map(List<Room> rooms, string level)
        {
            int min_x = 0;
            int min_y = 0;
            int max_x = 0;
            int max_y = 0;

            List<string> map = new();

            foreach (Room room in rooms)
            {
                if (min_x > room.x)
                    min_x = room.x;
                if (min_y > room.y)
                    min_y = room.y;
                if (max_x < room.x)
                    max_x = room.x;
                if (max_y < room.y)
                    max_y = room.y;
            }
            for (int y = max_y; y >= min_y; y--)
            {
                List<string> map_part = new();
                for (int x = min_x; x <= max_x; x++)
                {
                    if (rooms.Find(room => room.x == x && room.y == y) != null)
                    {
                        if (map_part.Count == 0)
                        {
                            map_part = rooms.Find(room => room.x == x && room.y == y).get_Room_Ascii();
                            continue;
                        }
                        List<string> room_ascii = rooms.Find(room => room.x == x && room.y == y).get_Room_Ascii();
                        List<string> _room_ = new();
                        int i = 0;
                        foreach (string part in map_part)
                        {
                            _room_.Add(part + room_ascii[i]);
                            i++;
                        }
                        map_part = _room_;
                    }
                    else
                    {
                        East east = new East();
                        North north = new North();
                        South south = new South();
                        int hight = east.get_Ascii().Count + north.get_Ascii().Count + south.get_Ascii().Count;
                        int width = north.get_Ascii()[0].Length;
                        if (map_part.Count == 0)
                        {
                            for (int i = 0; i < hight; i++)
                            {
                                map_part.Add(new string(' ', width));
                            }
                            continue;
                        }

                        List<string> _room_ = new();
                        foreach (string part in map_part)
                        {
                            _room_.Add(part + new string(' ', width));
                        }
                        map_part = _room_;
                    }
                }
                foreach (string part in map_part)
                {
                    map.Add(part);
                }
            }
            Write_File(map, $"lvl-{level}_map");
        }
    }
}