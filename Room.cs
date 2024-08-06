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

        private bool north_path = false;
        private bool south_path = false;
        private bool west_path = false;
        private bool east_path = false;

        private Random random = new(Global_Values.Seed);
        private int new_doors = 0;

        public int id { get; private set; }
        public bool visited { get; private set; }
        public int ident { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        private List<string> _room_Ascii = new List<string>();

        public Room(int id, int x = 0, int y = 0, int max_new = 0,
            bool north_block = false, bool south_block = false, bool west_block = false, bool east_block = false,
            bool north_path = false, bool south_path = false, bool west_path = false, bool east_path = false)
        {
            this.id = id;
            visited = false;
            new_doors = max_new;

            _north_block = north_block;
            _south_block = south_block;
            _west_block = west_block;
            _east_block = east_block;

            this.north_path = north_path;
            this.south_path = south_path;
            this.west_path = west_path;
            this.east_path = east_path;

            this.x = x;
            this.y = y;

            Room_Construct();
        }

        public List<string> get_Room_Ascii()
        {
            return _room_Ascii;
        }

        public void is_visited(bool is_visitied)
        {
            visited = is_visitied;
        }

        private void Room_Construct()
        {
            List<bool> block = new() { false, false, false };
            if (new_doors <= 2)
            {
                if (new_doors == 2)
                    block = [true, false, false];
                if (new_doors == 1)
                    block = [true, true, false];
                if (new_doors == 0)
                    block = [true, true, true];
                int n = block.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    bool value = block[k];
                    block[k] = block[n];
                    block[n] = value;
                }
            }
            int block_chance = new_doors >= 4 ? 5 : 40;
            bool _north_block;
            bool _south_block;
            bool _west_block;
            bool _east_block;
            if (north_path)
            {
                _north_block = false;
                _south_block = this._south_block || random.Next(100) <= block_chance || block[0];
                _west_block = this._west_block || random.Next(100) <= block_chance || block[1];
                _east_block = this._east_block || random.Next(100) <= block_chance || block[2];
            }
            else if (south_path)
            {
                _north_block = this._north_block || random.Next(100) <= block_chance || block[0];
                _south_block = false;
                _west_block = this._west_block || random.Next(100) <= block_chance || block[1];
                _east_block = this._east_block || random.Next(100) <= block_chance || block[2];
            }
            else if (west_path)
            {
                _north_block = this._north_block || random.Next(100) <= block_chance || block[0];
                _south_block = this._south_block || random.Next(100) <= block_chance || block[1];
                _west_block = false;
                _east_block = this._east_block || random.Next(100) <= block_chance || block[2];
            }
            else
            {
                _north_block = this._north_block || random.Next(100) <= block_chance || block[0];
                _south_block = this._south_block || random.Next(100) <= block_chance || block[1];
                _west_block = this._west_block || random.Next(100) <= block_chance || block[2];
                _east_block = false;
            }
            _room_Ascii = Generate_Room(_north_block, _east_block, _south_block, _west_block);

            //    0 → deadend
            //    1 → west
            //   10 → north
            //  100 → east
            // 1000 → south
            ident = 0;
            if (!_west_block && !west_path)
            {
                ident += 1;
            }
            if (!_north_block && !north_path)
            {
                ident += 10;
            }
            if (!_east_block && !east_path)
            {
                ident += 100;
            }
            if (!_south_block && !south_path)
            {
                ident += 1000;
            }
            //Global_Values.room_Ident = ident;


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
                room.Add(_west[i] + new string(' ', _north[0].Length - _east[i].Length - _west[i].Length) + _east[i]);
            }
            foreach (string s in _south)
            {
                room.Add(s);
            }
            return room;
        }
    }
}
