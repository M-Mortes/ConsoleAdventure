using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using ConsoleAdventure.Entitys;
using ConsoleAdventure.Controller;
using System.Reflection.Emit;

/* TODO:
 * Aktionen ~
 * Erkunden ☺
 * Speichern ☺
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
        private static Player _player;
        private static Enemy_Controller _ec;
        private static File_Controller _fc;
        private static Room_Controller _rc;
        private static Console_Controller _cc;
        private static Action_Controller _ac;

        static void Main(string[] args)
        {
            _player = (Player)new Player().Normal();
            _ec = new Enemy_Controller(_player);
            _rc = new Room_Controller(_player);
            _fc = new File_Controller(_player, _rc);
            _cc = new Console_Controller(_player, _rc);
            _ac = new Action_Controller(_player, _rc, _cc, _fc);

            _player.level = 1;
            Global_Values.action_Ident = 'x';
            Global_Values.gamestate = 1;
            Global_Values.level = 1;

            //debug
            //Global_Values.seed = 1;
            //end

            Global_Values.rng = Global_Values.seed == 0 ? new() : new(Global_Values.seed);
            new_Map();
            //debug
            // _cc.generate_View();
            // _cc.generate_Enemy_View();
            //end


            while (true)
            {
                _ac.next_Action();
                _ac.next_Reaction();
            }
        }
        public static void new_Map()
        {
            _rc.generate_Map();
            _fc.write_Map(_rc._rooms, $"{Global_Values.level}");
            _ac.new_Room_Enter(_rc._rooms[Global_Values.rng.Next(_rc._rooms.Count)]);
            _ac.generate_Room_View();
        }
    }
}
