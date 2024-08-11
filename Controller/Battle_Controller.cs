using ConsoleAdventure.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Controller
{
    internal class Battle_Controller
    {
        private Player _player;
        private Enemy _enemy;

        public Battle_Controller(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }


    }
}
