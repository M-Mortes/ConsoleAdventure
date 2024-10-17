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
        private Room_Controller _rc;

        public File_Controller(Player player, Room_Controller rc)
        {
            _player = player;
            _rc = rc;
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

        public void save(bool player = false, bool map = false)
        {
            if (player)
            {
                List<string> construct = new();
                construct.Add($"{_player.level}");
                construct.Add($"{_player.room_id}");
                construct.Add($"{_player.class_name}");
                construct.Add($"{_player.perc_multi}");
                construct.Add($"{_player.dex_multi}");
                construct.Add($"{_player.char_multi}");
                construct.Add($"{_player.int_multi}");
                construct.Add($"{_player.agi_multi}");
                construct.Add($"{_player.lck_multi}");
                Write_File(construct, "player");
            }
            else if (map)
            {
                List<Room> rooms = _rc._rooms;
                List<string> construct = new();
                foreach (Room room in rooms)
                {
                    construct.Add($"{room.id}");
                    construct.Add($"{room.x}");
                    construct.Add($"{room.y}");
                    construct.Add($"{room._new_doors}");
                    construct.Add($"{room.north_block}");
                    construct.Add($"{room.south_block}");
                    construct.Add($"{room.west_block}");
                    construct.Add($"{room.east_block}");
                    construct.Add($"{!room.north_block}");
                    construct.Add($"{!room.south_block}");
                    construct.Add($"{!room.west_block}");
                    construct.Add($"{!room.east_block}");
                    construct.Add($"{room.visited}");
                    construct.Add("##+##");
                }
                Write_File(construct, "rooms");
            }
        }

        public void load(bool player = false, bool map = false)
        {
            if (player && File.Exists("player.txt"))
            {
                List<string> construct = Read_File("player");

                _player.level = Int32.Parse(construct[0]);
                _player.room_id = Int32.Parse(construct[1]);
                _player.room = _rc._rooms.Find(room => room.id == Int32.Parse(construct[1]));
                _player.class_name = construct[2];
                _player.perc_multi = float.Parse(construct[3]);
                _player.dex_multi = float.Parse(construct[4]);
                _player.char_multi = float.Parse(construct[5]);
                _player.int_multi = float.Parse(construct[6]);
                _player.agi_multi = float.Parse(construct[7]);
                _player.lck_multi = float.Parse(construct[8]);

            }
            else if (map && File.Exists("rooms.txt"))
            {
                List<string> construct = Read_File("rooms");
                List<string> room_const = new();
                List<Room> rooms = new();
                foreach (string line in construct)
                {
                    room_const.Add(line);
                    if (line.Equals("##+##"))
                    {
                        rooms.Add(new Room(
                            Int32.Parse(room_const[0]),
                            Int32.Parse(room_const[1]),
                            Int32.Parse(room_const[2]),
                            Int32.Parse(room_const[3]),
                            bool.Parse(room_const[4]),
                            bool.Parse(room_const[5]),
                            bool.Parse(room_const[6]),
                            bool.Parse(room_const[7]),
                            bool.Parse(room_const[8]),
                            bool.Parse(room_const[9]),
                            bool.Parse(room_const[10]),
                            bool.Parse(room_const[11]),
                            bool.Parse(room_const[12])));
                        room_const = new();
                    }
                }
                _rc._rooms = rooms;
                _rc.set_Neighbors();
            }
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