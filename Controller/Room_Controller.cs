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
        private int _room_id = 0;
        private List<Room> _rooms = new List<Room>();
        private Room room;
        private int door_count = 0;

        Random rand = new(Global_Values.Seed);

        public List<string> get_Current_Room()
        {
            return _rooms.Find(room => room.id == 1).get_Room_Ascii();
        }

        public void generate_Map(int level)
        {
            _room_id = 1;
            Global_Values.room_count = 6 + level + rand.Next(0, level);
            rooms(new Room(_room_id, max_new: Global_Values.room_count));

            File_Controller _cf = new File_Controller();
            _cf.write_Map(_rooms, $"{level}");
        }

        private void rooms(Room room)
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
            bool block_west = true;
            bool block_east = true;
            bool block_south = true;
            bool block_north = true;
            foreach (char item in ident.ToString().ToCharArray())
            {
                if (item.Equals('1'))
                    door_count++;
            }
            if (room.id != 1)
                door_count--;
            if (ident >= 1000)
            {
                ident -= 1000;
                x = room.x;
                y = room.y - 1;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    (block_north, block_west, block_south, block_east) = get_blocked(1000, x, y);
                    rooms(new Room(_room_id, north_path: true, y: room.y - 1, x: room.x, max_new: Global_Values.room_count - (door_count + _room_id - 1),
                        north_block: block_north, south_block: block_south, east_block: block_east, west_block: block_west));
                }
            }
            if (ident >= 100)
            {
                ident -= 100;
                x = room.x + 1;
                y = room.y;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    (block_north, block_west, block_south, block_east) = get_blocked(100, x, y);
                    rooms(new Room(_room_id, west_path: true, x: room.x + 1, y: room.y, max_new: Global_Values.room_count - (door_count + _room_id - 1),
                        north_block: block_north, south_block: block_south, east_block: block_east, west_block: block_west));
                }
            }
            if (ident >= 10)
            {
                ident -= 10;
                x = room.x;
                y = room.y + 1;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    (block_north, block_west, block_south, block_east) = get_blocked(10, x, y);
                    rooms(new Room(_room_id, south_path: true, y: room.y + 1, x: room.x, max_new: Global_Values.room_count - (door_count + _room_id - 1),
                        north_block: block_north, south_block: block_south, east_block: block_east, west_block: block_west));
                }
            }
            if (ident >= 1)
            {
                ident -= 1;
                x = room.x - 1;
                y = room.y;
                if (_rooms.Find(room => room.x == x && room.y == y) == null)
                {
                    (block_north, block_west, block_south, block_east) = get_blocked(10, x, y);
                    rooms(new Room(_room_id, east_path: true, x: room.x - 1, y: room.y, max_new: Global_Values.room_count - (door_count + _room_id - 1),
                        north_block: block_north, south_block: block_south, east_block: block_east, west_block: block_west));
                }
            }
        }
        private (bool north, bool west, bool south, bool east) get_blocked(int indent, int x, int y)
        {
            bool block_north = false;
            bool block_west = false;
            bool block_south = false;
            bool block_east = false;
            Room? room_north = _rooms.Find(room => room.x == x && room.y == y + 1);
            Room? room_south = _rooms.Find(room => room.x == x && room.y == y - 1);
            Room? room_west = _rooms.Find(room => room.x == x - 1 && room.y == y);
            Room? room_east = _rooms.Find(room => room.x == x + 1 && room.y == y);
            // 1
            if (room_east != null && indent != 1)
                block_east = room_east.west_block;
            // 10
            if (room_south != null && indent != 10)
                block_south = room_south.north_block;
            // 100
            if (room_west != null && indent != 100)
                block_west = room_west.east_block;
            // 1000
            if (room_north != null && indent != 1000)
                block_north = room_north.south_block;
            return (block_north, block_west, block_south, block_east);
        }
    }
}
