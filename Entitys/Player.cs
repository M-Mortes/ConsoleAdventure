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
        public Room room { get; set; }
        private float exp_to_level = 100f;
        private float current_exp = 0f;

        public Player()
        {

        }

        public void exp_gain(float exp)
        {
            while (exp > 0)
            {
                current_exp += exp;
                while (current_exp >= exp_to_level)
                {
                    current_exp -= exp_to_level;
                    exp_to_level *= 1.2f;
                    _Level_Up();
                }
            }
        }

        private void _Level_Up()
        {
            level += 1;
        }
    }
}
