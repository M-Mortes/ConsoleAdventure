using ConsoleAdventure.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ConsoleAdventure
{
    internal class Enemy
    {
        Human entity_h = new Human();
        Human_Warrior entity_hw = new Human_Warrior();
        Human_Mage entity_hm = new Human_Mage();
        Random rand = new Random();

        int level = 0;
        float health = 0f;
        float evation = 0f;
        float crit = 0f;
        float dodge = 0f;
        float _stat_str = 0f;
        float _stat_perc = 0f;
        float _stat_dex = 0f;
        float _stat_char = 0f;
        float _stat_int = 0f;
        float _stat_agi = 0f;
        float _stat_lck = 0f;

        public List<string> ascii = new List<string>(); 

        public Enemy(int lvl = 0)
        {
            this.level = lvl;
            float lvl_points = level * 0.04f;
            int nbr = rand.Next(3);
            if (nbr == 0)
            {
                var enemy = entity_h;
                _stat_str = enemy.str_multi;
                _stat_perc = enemy.perc_multi;
                _stat_dex = enemy.dex_multi;
                _stat_char = enemy.char_multi;
                _stat_int = enemy.int_multi;
                _stat_agi = enemy.agi_multi;
                _stat_lck = enemy.lck_multi;
                ascii = enemy.get_Ascii();
            }
            else if (nbr == 1)
            {
                var enemy = entity_hw;
                _stat_str = enemy.str_multi;
                _stat_perc = enemy.perc_multi;
                _stat_dex = enemy.dex_multi;
                _stat_char = enemy.char_multi;
                _stat_int = enemy.int_multi;
                _stat_agi = enemy.agi_multi;
                _stat_lck = enemy.lck_multi;
                ascii = enemy.get_Ascii();
            }
            else if (nbr == 2)
            {
                var enemy = entity_hm;
                _stat_str = enemy.str_multi;
                _stat_perc = enemy.perc_multi;
                _stat_dex = enemy.dex_multi;
                _stat_char = enemy.char_multi;
                _stat_int = enemy.int_multi;
                _stat_agi = enemy.agi_multi;
                _stat_lck = enemy.lck_multi;
                ascii = enemy.get_Ascii();
            }
        }

        public List<string> get_stats()
        {
            List<string> stats = new List<string>();
            stats.Add("Str:  " + _stat_str.ToString());
            stats.Add("Perc: " + _stat_perc.ToString());
            stats.Add("Dex:  " + _stat_dex.ToString());
            stats.Add("Char: " + _stat_char.ToString());
            stats.Add("Int:  " + _stat_int.ToString());
            stats.Add("Agi:  " + _stat_agi.ToString());
            stats.Add("Luck: " + _stat_lck.ToString());
            return stats;
        }
    }
}
