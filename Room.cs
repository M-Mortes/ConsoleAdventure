using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using ConsoleAdventure.Room_Parts;

namespace ConsoleAdventure
{
    internal class Room
    {
        private bool _north_path = false;
        private bool _south_path = false;
        private bool _west_path = false;
        private bool _east_path = false;

        public int _new_doors = 0;

        public bool north_block = false;
        public bool south_block = false;
        public bool west_block = false;
        public bool east_block = false;

        public int open_doors = 0;
        public Room? room_north;
        public Room? room_south;
        public Room? room_west;
        public Room? room_east;

        public int id { get; private set; }
        public bool visited { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        private List<string> _room_Ascii = new List<string>();

        public Room(int id, int x = 0, int y = 0, int doors = 0,
            bool north_block = false, bool south_block = false, bool west_block = false, bool east_block = false,
            bool north_path = false, bool south_path = false, bool west_path = false, bool east_path = false)
        {
            this.id = id;
            visited = false;
            _new_doors = doors;

            this.north_block = north_block;
            this.south_block = south_block;
            this.west_block = west_block;
            this.east_block = east_block;

            this._north_path = north_path;
            this._south_path = south_path;
            this._west_path = west_path;
            this._east_path = east_path;

            this.x = x;
            this.y = y;

            Room_Construct();
        }

        public List<string> get_Room_Ascii()
        {
            return _room_Ascii;
        }

        public void set_Visited()
        {
            visited = true;
        }

        private void Room_Construct()
        {
            bool _north_block = false;
            bool _south_block = false;
            bool _west_block = false;
            bool _east_block = false;

            if (_new_doors != 0)
            {
                var sites = distrbute_Doors(_new_doors);
                _north_block = sites.north;
                _south_block = sites.south;
                _west_block = sites.west;
                _east_block = sites.east;
            }
            else
            {
                _north_block = true;
                _south_block = true;
                _west_block = true;
                _east_block = true;
            }

            if (id == 1)
            {
                List<bool> list = new List<bool>() { false, true, false, false };
                list.Shuffle();
                _north_block = list[0];
                _east_block = list[1];
                _south_block = list[2];
                _west_block = list[3];
                open_doors = 3;
            }

            _north_block = _north_path ? false : north_block ? north_block : _north_block;
            _south_block = _south_path ? false : south_block ? south_block : _south_block;
            _west_block = _west_path ? false : west_block ? west_block : _west_block;
            _east_block = _east_path ? false : east_block ? east_block : _east_block;

            _room_Ascii = Generate_Room(_north_block, _east_block, _south_block, _west_block);

            north_block = _north_block;
            south_block = _south_block;
            west_block = _west_block;
            east_block = _east_block;
            if (_west_block && _north_block && _south_block && _east_block)
            {
                Room_Construct();
                return;
            }
        }

        private (bool north, bool south, bool west, bool east) distrbute_Doors(int amount)
        {
            List<string> orient = new() { "north", "south", "west", "east" };

            bool _north_block = !_north_path;
            bool _south_block = !_south_path;
            bool _west_block = !_west_path;
            bool _east_block = !_east_path;
            List<int> chances = new() { 7, 17, 46, 30 };

            if (amount < 0)
                return (_north_block, _south_block, _west_block, _east_block);

            if (amount >= 3)
            {
                int deadend_chance = chances[0];
                int path_1_chance = chances[1];
                int path_2_chance = chances[2];
                int path_3_chance = chances[3];

                int chance = Global_Values.rng.Next(100);
                if (chance < deadend_chance)
                    amount = 0;
                else if (chance < deadend_chance + path_1_chance)
                    amount = 1;
                else if (chance < path_2_chance + path_1_chance + deadend_chance)
                    amount = 2;
                else if (chance < path_3_chance + path_2_chance + path_1_chance + deadend_chance)
                    amount = 3;
            }

            open_doors = amount;
            _new_doors = amount;

            if (amount == 3)
            {
                amount = 0;
                _north_block = false;
                _south_block = false;
                _west_block = false;
                _east_block = false;
            }

            while (amount > 0)
            {
                int chance = Global_Values.rng.Next(orient.Count);
                string door = orient[chance];
                if (_north_block && door.Equals("north"))
                {
                    _north_block = false;
                    orient.Remove(door);
                }
                else if (_south_block && door.Equals("south"))
                {
                    _south_block = false;
                    orient.Remove(door);
                }
                else if (_west_block && door.Equals("west"))
                {
                    _west_block = false;
                    orient.Remove(door);
                }
                else if (_east_block && door.Equals("east"))
                {
                    _east_block = false;
                    orient.Remove(door);
                }
                else if (!_north_block && !_south_block && !_west_block && !_east_block)
                    amount = 0;
                else
                    continue;
                amount--;
            }
            return (_north_block, _south_block, _west_block, _east_block);
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
            int width = _north[0].Length;
            int height = _north.Count + _east.Count + _south.Count + _west.Count;

            foreach (string s in _north)
            {
                room.Add(s);
            }
            for (int i = 0; i < _east.Count; i++)
            {
#if DEBUG
                room.Add(_west[i] + new string(' ', (_north[0].Length - _east[i].Length - _west[i].Length) / 2 - id.ToString().Length) + id + new string(' ', (_north[0].Length - _east[i].Length - _west[i].Length) / 2) + _east[i]);
#else
                room.Add(_west[i] + new string(' ', _north[0].Length - _east[i].Length - _west[i].Length) + _east[i]);
#endif
            }
            foreach (string s in _south)
            {
                room.Add(s);
            }

            return room;
        }
    }
}
