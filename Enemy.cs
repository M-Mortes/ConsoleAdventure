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
        int _level = 0;
        int _id = 0;
        float _health = 0f;
        float _evation = 0f;
        float _crit = 0f;
        float _dodge = 0f;
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
            this._level = lvl;
            float lvl_points = _level * 0.04f;
            List<Human> list = [new Human().Normal(), new Human().Warriro(), new Human().Mage()];
            int nbr = Global_Values.rng.Next(list.Count);

            Human enemy = list[nbr];
            _id = enemy.id;
            _stat_str = enemy.str_multi;
            _stat_perc = enemy.perc_multi;
            _stat_dex = enemy.dex_multi;
            _stat_char = enemy.char_multi;
            _stat_int = enemy.int_multi;
            _stat_agi = enemy.agi_multi;
            _stat_lck = enemy.lck_multi;
            ascii = enemy.get_Ascii();
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
