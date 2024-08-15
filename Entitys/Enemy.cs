using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ConsoleAdventure.Entitys
{
    internal class Enemy : Human
    {
        int _level = 0;
        Human.Type _id;

        public List<string> ascii = new List<string>();

        public Enemy(int lvl = 1, int enemytype = -1)
        {
            Human enemy = new Human();
            List<Human> list = [new Human().Normal(), new Human().Warrior(), new Human().Mage()];
            _level = lvl;
            float lvl_points = _level * 0.04f;
            int nbr = Global_Values.rng.Next(list.Count);

            if (enemytype != -1)
                enemy = list[enemytype];
            else
                enemy = list[nbr];

            _id = enemy.type;
            ascii = enemy.get_Ascii();
        }
    }
}
