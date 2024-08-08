using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using ConsoleAdventure.Entitys;
using ConsoleAdventure.Controller;

namespace ConsoleAdventure
{
    class Main_Game_Loop
    {
        private static Player player = (Player)new Player().Normal();
        private static Console_Controller _cc = new Console_Controller(player);
        private static Room_Controller _rc = new Room_Controller(player);
        private static Enemy_Controller _ec = new Enemy_Controller(player);
        private static Action_Controller _ac = new Action_Controller(player);

        static void Main(string[] args)
        {
#if DEBUG
            Global_Values.level = 1;
            // _cc.generate_View();
            Global_Values.seed = 1;
            // _cc.generate_Room_View();
            _cc.generate_Enemy_View();
#else
#endif
            Global_Values.rng = Global_Values.seed == 0 ? new() : new(Global_Values.seed);
            Global_Values.action_Ident = -1;
            Global_Values.gamestate = 1;

            while (true)
            {
                _ac.next_Action();
                _ac.next_Reaction();
            }
        }

    }
}
