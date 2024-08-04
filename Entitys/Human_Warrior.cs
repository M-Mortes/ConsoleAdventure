using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Entitys
{
    internal class Human_Warrior
    {
        public float str_multi = 1.5f;
        public float perc_multi = 0.7f;
        public float dex_multi = 1.4f;
        public float char_multi = 0.6f;
        public float int_multi = 0.8f;
        public float agi_multi = 1.1f;
        public float lck_multi = 0.9f;

        public List<string> get_Ascii()
        {
            List<string> knight = [
                "         ____         ",
                "        /    \\       ",
                "       /      \\      ",
                "       \\      /      ",
                "        \\____/       ",
                "        [/   \\]  /\\ ",
                "  ____ [/ / \\ \\] || ",
                " /    \\/ /| |\\ \\]||",
                "/      \\/[| |]\\ \\||",
                "\\      / [| |] \\ || ",
                " \\____/  [| |]  \\II ",
                "        [_|_|_]  II   ",
                "        / / \\ \\     ",
                "       / /   \\ \\    ",
                "      / /     \\ \\   ",
                "     /_/       \\_\\  "];
            return knight;
        }
    }
}
