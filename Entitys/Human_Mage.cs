using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Entitys
{
    internal class Human_Mage
    {
        // 1.0 = 100%
        // together 7.0 
        // lck 0.1 = 0.2 other
        public float str_multi = 0.7f;
        public float perc_multi = 0.9f;
        public float dex_multi = 0.8f;
        public float char_multi = 1.2f;
        public float int_multi = 1.4f;
        public float agi_multi = 0.6f;
        public float lck_multi = 1.2f;

        public List<string> get_Ascii()
        {
            List<string> mage = [
                "    ____        ",
                " __/    \\__    ",
                "/__________\\   ",
                "  /      | __   ",
                "  \\      |/  \\",
                "   \\____/ |  | ",
                "    /   \\ \\||/",
                "   / / \\ \\ || ",
                "  / /| |\\ \\|| ",
                " / / | | \\ ||  ",
                "/_/  | |  \\||  ",
                "     | |   ||   ",
                "    _|_|_  ||   ",
                "   / / \\ \\ || ",
                "  / /   \\ \\|| ",
                " / /     \\ ||  ",
                "/_/       \\||  " ];
            return mage;
        }
    }
}
