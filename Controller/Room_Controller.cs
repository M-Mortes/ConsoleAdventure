using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    * alt  26 → →
    * alt  28 → ∟
    * alt  29 → ↔
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
    * alt 207 → ¤
    * alt 217 → ┘
    * alt 218 → ┌
    */

namespace ConsoleAdventure.Controller
{
    internal class Room_Controller
    {
        private List<String> Path_North(bool block = false)
        {
            List<String> room = new List<String>();
            if (!block)
                room = [
                    "╔╝   ╚╗"];
            else
                room = [
                    "╔═════╗"];
            return room;
        }

        private List<String> Path_South(bool block = false)
        {
            List<String> room = new List<String>();
            if (!block)
                room = [
                    "╚╗   ╔╝"];
            else
                room = [
                    "╚═════╝"];
            return room;
        }

        private List<String> Path_West(bool block = false)
        {
            List<String> room = new List<String>();
            if (!block)
                room = [
                    " ",
                    "╝",
                    "╗",
                    " "];
            else
                room = [
                    " ",
                    "║",
                    "║",
                    " "];
            return room;
        }
        
        private List<String> Path_East(bool block = false)
        {
            List<String> room = new List<String>();
            if (!block)
                room = [
                    " ",
                    "╚",
                    "╔",
                    " "];
            else
                room = [
                    " ",
                    "║",
                    "║",
                    " "];
            return room;
        }

        public List<String> Generate_Room(bool north = false, bool east = false, bool south = false, bool west = false)
        {
            List<String> room = new List<String>();
            List<String> _north = Path_North(north);
            List<String> _east = Path_East(east);
            List<String> _south = Path_South(south);
            List<String> _west = Path_West(west);
            room.Add(_north[0]);
            room.Add(_west[1] + new String(' ', _north[0].Length - 2) + _east[1]);
            room.Add(_west[2] + new String(' ', _north[0].Length - 2) + _east[2]);
            room.Add(_south[0]);
            return room;
        }

    }
}
