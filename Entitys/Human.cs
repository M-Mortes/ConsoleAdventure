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


    /*
     * "    ____     ",
     * "   /    \    ",
     * "  /      |   ",
     * "  \      |   ",
     * "   \____/    ",
     * "    /   \    ",
     * "   / / \ \   ",
     * "  / /| |\ \  ",
     * " / / | | \ \ ",
     * "/_/  | |  \_\",
     * "    _|_|_    ",
     * "   / / \ \   ",
     * "  / /   \ \  ",
     * " / /     \ \ ",
     * "/_/       \_\" 
     */
    internal class Human
    {
        public string class_name {  get; set; }
        public float str_multi = 0f;
        public float perc_multi = 0f;
        public float dex_multi = 0f;
        public float char_multi =0f;
        public float int_multi = 0f;
        public float agi_multi = 0f;
        public float lck_multi = 99f;

        public int id = 1;

        public Human Normal()
        {
            class_name = "Normal";
            str_multi = 1.0f;
            perc_multi = 1.0f;
            dex_multi = 1.0f;
            char_multi = 1.0f;
            int_multi = 1.0f;
            agi_multi = 1.0f;
            lck_multi = 1.0f;

            id = 1;
            return this;
        }
        public Human Mage()
        {
            class_name = "Mage";
            str_multi = 0.7f;
            perc_multi = 0.9f;
            dex_multi = 0.8f;
            char_multi = 1.2f;
            int_multi = 1.4f;
            agi_multi = 0.6f;
            lck_multi = 1.2f;

            id = 2;
            return this;
        }
        public Human Warriro()
        {
            class_name = "Warriror";
            str_multi = 1.5f;
            perc_multi = 0.7f;
            dex_multi = 1.4f;
            char_multi = 0.6f;
            int_multi = 0.8f;
            agi_multi = 1.1f;
            lck_multi = 0.9f;

            id = 3;
            return this;
        }

        public List<string> get_Ascii()
        {
            List<string> normal = [
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
                "    _|_|_      ",
                "   / / \\ \\   ",
                "  / /   \\ \\  ",
                " / /     \\ \\ ",
                "/_/       \\_\\"];
            if (id == 1)
                return normal;

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
                "    _|_|_  ||   ",
                "   / / \\ \\ || ",
                "  / /   \\ \\|| ",
                " / /     \\ ||  ",
                "/_/       \\||  " ];
            if (id == 2)
                return mage;

            List<string> knight = [
                "         ____         ",
                "        /    \\       ",
                "       /      \\      ",
                "       \\      /      ",
                "        \\____/   /\\ ",
                "        [/   \\]  || ",
                "  ____ [/ / \\ \\] || ",
                " /    \\/ /| |\\ \\]||",
                "/      \\/[| |]\\ \\||",
                "\\      / [| |] \\ II ",
                " \\____/ [_|_|_] \\II ",
                "       [/ / \\ \\]    ",
                "      [/ /   \\ \\]   ",
                "     [/ /     \\ \\]  ",
                "    [/_/       \\_\\] "];
            if (id == 3)
                return knight;

            List<string> _default = [
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               "];
            return _default;
        }

    }
}
