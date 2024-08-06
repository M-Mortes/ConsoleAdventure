using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Room_Parts
{
    internal class North
    {
        public List<string> get_Ascii(bool block = false)
        {
            List<string> room;
            if (!block)
                room = [
                    "╔═══╝  ╚═══╗"];
            else
                room = [
                    "╔══════════╗"];
            return room;
        }
    }
}
