using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using ConsoleAdventure.Entitys;
using ConsoleAdventure.Controller;

/* TODO:
 * Aktionen ~
 * Erkunden ☺
 * Speichern
 * Kampf
 * Ausrüstung
 * Inventar
 * Events (was auch immer das wird)
 * statuseffekte
 * Gegner +
 * Klassen +
 * Schadensarten (magie, physisch, fern-, special-, ulti....)
 * custom ausrüstung via txt
 * custom klassen / gegner via txt
 * */

namespace ConsoleAdventure
{
    class Main_Game_Loop
    {
        private static Player player = (Player)new Player().Normal();
        private static Room_Controller _rc = new Room_Controller(player);
        private static Console_Controller _cc = new Console_Controller(player, _rc);
        private static Enemy_Controller _ec = new Enemy_Controller(player);
        private static Action_Controller _ac = new Action_Controller(player, _rc, _cc);

        static void Main(string[] args)
        {
            player.level = 1;
            Global_Values.action_Ident = 'x';
            Global_Values.gamestate = 1;
            Global_Values.level = 1;

            //debug
            //Global_Values.seed = 1;
            //end

            Global_Values.rng = Global_Values.seed == 0 ? new() : new(Global_Values.seed);
            _rc.generate_Map(Global_Values.level);
            _ac.new_Room_Enter(_rc._rooms[Global_Values.rng.Next(_rc._rooms.Count)]);

            //debug
            // _cc.generate_View();
            _ac.generate_Room_View();
            // _cc.generate_Enemy_View();
            //end


            while (true)
            {
                _ac.next_Action();
                _ac.next_Reaction();
            }
        }
    }
}
