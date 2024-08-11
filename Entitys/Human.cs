using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        public string class_name { get; private set; }
        public int level { get; set; }
        public enum Type { Normal, Mage, Warrior }
        public Type type { get; private set; }

        // base stats
        public float stat_str { get; set; }
        public float stat_perc { get; set; }
        public float stat_dex { get; set; }
        public float stat_char { get; set; }
        public float stat_int { get; set; }
        public float stat_agi { get; set; }
        public float stat_lck { get; set; }

        // stat multi
        public float str_multi { get; private set; }
        public float perc_multi { get; private set; }
        public float dex_multi { get; private set; }
        public float char_multi { get; private set; }
        public float int_multi { get; private set; }
        public float agi_multi { get; private set; }
        public float lck_multi { get; private set; }

        // battle stats
        public float health { get; set; }
        public float initiative { get; set; }
        public float physical_dmg { get; set; }
        public float magic_dmg { get; set; }
        public float mana { get; set; }
        public float evation { get; set; }
        public float crit { get; set; }
        public float dodge { get; set; }

        // gear stats
        public float str_gear_boni { get; set; }
        public float perc_gear_boni { get; set; }
        public float dex_gear_boni { get; set; }
        public float char_gear_boni { get; set; }
        public float int_gear_boni { get; set; }
        public float agi_gear_boni { get; set; }
        public float lck_gear_boni { get; set; }

        // level boni
        public float str_level_boni { get; set; }
        public float perc_level_boni { get; set; }
        public float dex_level_boni { get; set; }
        public float char_level_boni { get; set; }
        public float int_level_boni { get; set; }
        public float agi_level_boni { get; set; }
        public float lck_level_boni { get; set; }



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

            type = Type.Normal;
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

            type = Type.Mage;
            return this;
        }
        public Human Warrior()
        {
            class_name = "Warriror";
            str_multi = 1.5f;
            perc_multi = 0.7f;
            dex_multi = 1.4f;
            char_multi = 0.6f;
            int_multi = 0.8f;
            agi_multi = 1.1f;
            lck_multi = 0.9f;

            type = Type.Warrior;
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
            if (type == Type.Normal)
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
            if (type == Type.Mage)
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
            if (type == Type.Warrior)
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

        public List<string> get_stats()
        {
            List<string> stats = new List<string>();
            stats.Add("Str:  " + (str_multi * level + str_gear_boni + str_level_boni).ToString());
            stats.Add("Perc: " + (perc_multi * level + perc_gear_boni + perc_level_boni).ToString());
            stats.Add("Dex:  " + (dex_multi * level + dex_gear_boni + dex_level_boni).ToString());
            stats.Add("Char: " + (char_multi * level + char_gear_boni + char_level_boni).ToString());
            stats.Add("Int:  " + (int_multi * level + int_gear_boni + int_level_boni).ToString());
            stats.Add("Agi:  " + (agi_multi * level + agi_gear_boni + agi_level_boni).ToString());
            stats.Add("Luck: " + (lck_multi * level + lck_gear_boni + lck_level_boni).ToString());
            return stats;
        }

        public List<float> get_stats_raw()
        {
            List<float> stats = new List<float>();
            stats.Add(str_multi * level + str_gear_boni + str_level_boni);
            stats.Add(perc_multi * level + perc_gear_boni + perc_level_boni);
            stats.Add(dex_multi * level + dex_gear_boni + dex_level_boni);
            stats.Add(char_multi * level + char_gear_boni + char_level_boni);
            stats.Add(int_multi * level + int_gear_boni + int_level_boni);
            stats.Add(agi_multi * level + agi_gear_boni + agi_level_boni);
            stats.Add(lck_multi * level + lck_gear_boni + lck_level_boni);
            return stats;
        }
    }
}
