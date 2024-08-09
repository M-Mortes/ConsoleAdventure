using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Entitys
{
    internal class Player : Human
    {
        public int room_id { get; set; }
        public int level { get; set; }
        public Room room { get; set; }
        float str_level_boni = 0f;
        float str_gear_boni = 0f;
        float perc_level_boni = 0f;
        float perc_gear_boni = 0f;
        float dex_level_boni = 0f;
        float dex_gear_boni = 0f;
        float char_level_boni = 0f;
        float char_gear_boni = 0f;
        float int_level_boni = 0f;
        float int_gear_boni = 0f;
        float agi_level_boni = 0f;
        float agi_gear_boni = 0f;
        float lck_level_boni = 0f;
        float lck_gear_boni = 0f;

        public Player()
        {

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
