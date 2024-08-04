using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Entitys
{
    /*
     * strength
     * perception
     * endurance
     * charisma
     * intelligenz
     * agility
     * luck
     */
    internal class Human
    {
        public float str_multi = 1.0f;
        public float perc_multi = 1.0f;
        public float dex_multi = 1.0f;
        public float char_multi = 1.0f;
        public float int_multi = 1.0f;
        public float agi_multi = 1.0f;
        public float lck_multi = 1.0f;

        public List<string> get_Ascii()
        {
            List<string> man = [
                "    ____       ",
                "   /    \\     ",
                "  /      |     ",
                "  \\      |    ",
                "   \\____/     ",
                "    /   \\     ",
                "   / / \\ \\   ",
                "  / /| |\\ \\  ",
                " / / | | \\ \\ ",
                "/_/  | |  \\_\\",
                "     | |       ",
                "    _|_|_      ",
                "   / / \\ \\   ",
                "  / /   \\ \\  ",
                " / /     \\ \\ ",
                "/_/       \\_\\"];
            return man;
        }
    }
}
