using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using ConsoleAdventure.Room_Parts;

namespace ConsoleAdventure
{
    internal class Room
    {
        private bool _north_block = false;
        private bool _south_block = false;
        private bool _west_block = false;
        private bool _east_block = false;

        public bool north_b = false;
        public bool south_b = false;
        public bool west_b = false;
        public bool east_b = false;

        private string _origin = "";
        public int id = 0;
        public string path_taken = "";

        private List<string> _room_Ascii = new List<string>();

        public Room(int id, string origin = "", bool north_block = false, bool south_block = false, bool west_block = false, bool east_block = false)
        {
            this.id = id;
            _origin = origin;
            _north_block = north_block;
            _south_block = south_block;
            _west_block = west_block;
            _east_block = east_block;
            Room_Construct();
        }

        public List<string> get_Room_Ascii()
        {
            return _room_Ascii;
        }

        public void set_path(string path)
        {
            path_taken = path;
        }

        private void Room_Construct()
        {
            bool origin_north = false;
            bool origin_south = false;
            bool origin_west = false;
            bool origin_east = false;

            Random random = new();

            switch (_origin)
            {
                case "north":
                    origin_north = true;
                    break;
                case "south":
                    origin_south = true;
                    break;
                case "west":
                    origin_west = true;
                    break;
                case "east":
                    origin_east = true;
                    break;
            }

            north_b = !origin_north && (_north_block || random.Next(2) == 1);
            south_b = !origin_south && (_south_block || random.Next(2) == 1);
            west_b = !origin_west && (_west_block || random.Next(2) == 1);
            east_b = !origin_east && (_east_block || random.Next(2) == 1);
            _room_Ascii = Generate_Room(north_b, east_b, south_b, west_b);
        }

        public List<string> Generate_Room(bool north_b = false, bool east_b = false, bool south_b = false, bool west_b = false)
        {
            North north = new North();
            South south = new South();
            West west = new West();
            East east = new East();

            List<string> room = [];
            List<string> _north = north.get_Ascii(north_b);
            List<string> _east = east.get_Ascii(east_b);
            List<string> _south = south.get_Ascii(south_b);
            List<string> _west = west.get_Ascii(west_b);
            room.Add(_north[0]);
            room.Add(_west[1] + new string(' ', _north[0].Length - 2) + _east[1]);
            room.Add(_west[2] + new string(' ', _north[0].Length - 2) + _east[2]);
            room.Add(_south[0]);
            return room;
        }
    }
}
