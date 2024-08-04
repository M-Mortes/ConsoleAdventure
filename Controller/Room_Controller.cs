using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
        private int _room_counter = -1;
        private List<Room> _rooms = new List<Room>();
        private Room room;

        public List<string> get_Current_Room()
        {
            return room.get_Room_Ascii();
        }

        public void new_Room()
        {
            _room_counter++;
            room = new Room(_room_counter);
            _rooms.Add(room);
        }
    }
}
