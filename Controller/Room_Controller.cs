using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    * alt  26 → →
    * alt 176 → ░
    * alt 177 → ▒
    * alt 178 → ▓
    * alt 219 → █
    * alt 186 → ║
    * alt 187 → ╗
    * alt 188 → ╝
    * alt 200 → ╚
    * alt 201 → ╔
    * alt 202 → ╩
    * alt 203 → ╦
    * alt 204 → ╠
    * alt 205 → ═
    * alt 206 → ╬
    * alt 191 → ┐
    * alt 192 → └
    * alt 193 → ┴
    * alt 194 → ┬
    * alt 195 → ├
    * alt 196 → ─
    * alt 197 → ┼
    * alt 217 → ┘
    * alt 218 → ┌
    */

namespace ConsoleAdventure.Controller
{
    internal class Room_Controller
    {
        public List<Room> _rooms = new List<Room>();

        private Player _player;
        private int _room_id = 0;

        public Room_Controller(Player player)
        {
            _player = player;
        }

        public List<string> get_Current_Room(int id)
        {
            return _rooms.Find(room => room.id == id).get_Room_Ascii();
        }

        public void generate_Map(int level)
        {
            _room_id = 1;
            Global_Values.room_count = 6 + level + Global_Values.rng.Next(0, level);
            _generate_Room(new Room(_room_id, doors: Global_Values.room_count));

            _rooms.FindAll(room => room.open_doors > 0);

            File_Controller _cf = new File_Controller();
            _cf.write_Map(_rooms, $"{level}");
        }

        private void _generate_Room(Room room)
        {
            /*
             * 
             * ↓ 1000  y - 1
             * → 100   x + 1
             * ↑ 10    y + 1
             * ← 1     x - 1
             * 
             * */
            _rooms.Add(room);
            _room_id++;

            int ident = room.ident;
            int x = 0;
            int y = 0;

            if (ident >= 1000)
            {
                ident -= 1000;
                x = room.x;
                y = room.y - 1;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    room.open_doors--;
                    get_blocked(x, y);
                }
            }
            if (ident >= 100)
            {
                ident -= 100;
                x = room.x + 1;
                y = room.y;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    room.open_doors--;
                    get_blocked(x, y);
                }
            }
            if (ident >= 10)
            {
                ident -= 10;
                x = room.x;
                y = room.y + 1;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    room.open_doors--;
                    get_blocked(x, y);
                }
            }
            if (ident >= 1)
            {
                ident -= 1;
                x = room.x - 1;
                y = room.y;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    room.open_doors--;
                    get_blocked(x, y);
                }
            }
        }

        private void get_blocked(int x, int y)
        {
            bool block_north = false;
            bool block_west = false;
            bool block_south = false;
            bool block_east = false;

            bool path_north = false;
            bool path_west = false;
            bool path_south = false;
            bool path_east = false;

            Room? room_north = _rooms.Find(room => room.x == x && room.y == y + 1);
            Room? room_south = _rooms.Find(room => room.x == x && room.y == y - 1);
            Room? room_west = _rooms.Find(room => room.x == x - 1 && room.y == y);
            Room? room_east = _rooms.Find(room => room.x == x + 1 && room.y == y);

            // 1
            if (room_east != null)
            {
                block_east = room_east.west_block;
                path_east = !block_east;
            }
            // 10
            if (room_south != null)
            {
                block_south = room_south.north_block;
                path_south = !block_south;
            }
            // 100
            if (room_west != null)
            {
                block_west = room_west.east_block;
                path_west = !block_west;
            }
            // 1000
            if (room_north != null)
            {
                block_north = room_north.south_block;
                path_north = !block_north;
            }

            int open_doors = 0;
            foreach (Room room in _rooms)
            {
                open_doors += room.open_doors;
            }

            _generate_Room(new Room(_room_id, x, y, Global_Values.room_count - (open_doors + 1 + _rooms.Count),
                        block_north, block_south, block_west, block_east, path_north, path_south, path_west, path_east));
        }
    }
}
