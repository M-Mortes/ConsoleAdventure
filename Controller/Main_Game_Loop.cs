using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using ConsoleAdventure.Entitys;

namespace ConsoleAdventure.Controller
{
    class Main_Game_Loop
    {
        private static Console_Controller _cc = new Console_Controller();
        private static Room_Controller _rc = new Room_Controller();
        private static Enemy_Controller _ec = new Enemy_Controller();
        private static Action_Controller _ac = new Action_Controller();

        static void Main(string[] args)
        {
            Global_Values.action_Ident = -1;
            Global_Values.gamestate = 1;
#if DEBUG
            // _cc.generate_View();
            _cc.generate_Room_View();
#endif
            while (Global_Values.action_Ident == -1)
            {
                _ac.next_Action();
                _ac.next_Reaction();
            }
        }

    }
}
