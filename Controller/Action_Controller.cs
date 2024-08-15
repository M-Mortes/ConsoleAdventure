using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConsoleAdventure.Entitys;

namespace ConsoleAdventure.Controller
{

    internal class Action_Controller
    {
        private Player _player;
        private Room_Controller _rc;
        private Console_Controller _cc;
        private File_Controller _fc;

        private static (List<string> _console_frame_1, List<string> _console_frame_2, List<string> _console_frame_3) _ccf;

        public Action_Controller(Player player, Room_Controller rc, Console_Controller cc, File_Controller fc)
        {
            _player = player;
            _rc = rc;
            _cc = cc;
            _fc = fc;
            _ccf = _cc.Clear_Console_Frame();
        }
        public void next_Action()
        {
            Console.Write("\n\rWhat to do.. ?: ");
            ConsoleKeyInfo key = Console.ReadKey();
            int gamestate = Global_Values.gamestate;
            List<char> room_cont = ['l', 'q', '/'];
            if (!_player.room.south_block)
                room_cont.Add('s');
            if (!_player.room.north_block)
                room_cont.Add('w');
            if (!_player.room.west_block)
                room_cont.Add('a');
            if (!_player.room.east_block)
                room_cont.Add('d');

            if (key.KeyChar.Equals('/'))
                if (Console.ReadKey().KeyChar.Equals('/'))
                    if (Console.ReadKey().KeyChar.Equals('d'))
                        if (Console.ReadKey().KeyChar.Equals('e'))
                            if (Console.ReadKey().KeyChar.Equals('b'))
                                if (Console.ReadKey().KeyChar.Equals('u'))
                                    if (Console.ReadKey().KeyChar.Equals('g'))
                                    {
                                        debug();
                                    }

            if (key.KeyChar.Equals('q'))
            {
                Console.WriteLine("\n\rAre you sure that you want to exit? y/n");
                if (Console.ReadKey().KeyChar.Equals('y'))
                {
                    Console.WriteLine("\n\rDo you want to save? y/n");
                    if (Console.ReadKey().KeyChar.Equals('y'))
                    {
                        _fc.save(map: true);
                        _fc.save(player: true);
                        Environment.Exit(0);
                    }
                    else
                        Environment.Exit(0);
                }
                else
                {
                    Console.Write("");
                    next_Action();
                    return;
                }

            }

            switch (gamestate)
            {
                case 0:

                    break;
                case 1:
                    if (room_cont.Contains(key.KeyChar))
                    {
                        Global_Values.action_Ident = key.KeyChar;
                    }
                    else
                    {
                        Console.Write("\n\rInvalid input");
                        next_Action();
                        return;
                    }
                    break;
            }
        }

        private void debug()
        {
            int gamestate = Global_Values.gamestate;
            Global_Values.gamestate = 0;
            var consoles = _cc.Clear_Console_Frame();
            Global_Values.frame_3_text = consoles._console_frame_3;
            Console.WriteLine();
            _cc.Update_Console();
            Console.Write("Debug: ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar.Equals('m'))
            {
                Console.Write("\n\rMap Level: ");
                string? line = Console.ReadLine();
                int num = 0;
                if(int.TryParse(line, out num))
                {
                    Global_Values.level = num;
                    _rc.generate_Map();
                    _fc.write_Map(_rc._rooms, $"{Global_Values.level}");
                    new_Room_Enter(_rc._rooms[Global_Values.rng.Next(_rc._rooms.Count)]);
                    generate_Room_View();
                    Global_Values.gamestate = gamestate;
                }
            }
        }

        public void next_Reaction()
        {
            int gamestate = Global_Values.gamestate;
            char ident = Global_Values.action_Ident;
            List<string> actions = Global_Values.actions;
            switch (gamestate)
            {
                case 0:
                    break;

                case 1:
                    switch (ident)
                    {
                        case 'w':
                            new_Room_Enter(_rc._rooms.Find(room => room.y == _player.room.y + 1 && room.x == _player.room.x));
                            break;
                        case 'a':
                            new_Room_Enter(_rc._rooms.Find(room => room.x == _player.room.x - 1 && room.y == _player.room.y));
                            break;
                        case 's':
                            new_Room_Enter(_rc._rooms.Find(room => room.y == _player.room.y - 1 && room.x == _player.room.x));
                            break;
                        case 'd':
                            new_Room_Enter(_rc._rooms.Find(room => room.x == _player.room.x + 1 && room.y == _player.room.y));
                            break;
                        case 'l':
                            _fc.load(map: true);
                            _fc.load(player: true);
                            _fc.write_Map(_rc._rooms, $"{Global_Values.level}");
                            Console.WriteLine("Loading complete!");
                            generate_Room_View();
                            break;
                    }
                    break;
            }
        }
        public void new_Room_Enter(Room new_Room)
        {
            _player.room = new_Room;
            _player.room_id = new_Room.id;
            new_Room.set_Visited();
            generate_Room_View();
        }

        public void generate_Enemy_View()
        {
            Enemy enemy = new Enemy();

            Global_Values.frame_1_text = _ccf._console_frame_1;
            Global_Values.frame_2_text = _ccf._console_frame_2;
            Global_Values.frame_3_text = _ccf._console_frame_3;

            Global_Values.frame_1_text = _cc.Add_To_Frame(Global_Values.frame_1_text, _cc.String_List_Combine(_player.get_Ascii(),
                _cc.Reverse_Char(enemy.ascii), Global_Values.frame_1_width));
            Global_Values.frame_2_text = _cc.String_Replace(Global_Values.frame_2_text, _cc.generate_Status_Table(enemy.get_stats()));
            _cc.Update_Console();
        }

        public void generate_Room_View()
        {
            Global_Values.frame_1_text = _ccf._console_frame_1;
            Global_Values.frame_2_text = _ccf._console_frame_2;
            Global_Values.frame_3_text = _ccf._console_frame_3;
            Global_Values.frame_1_text = _cc.Add_To_Frame(Global_Values.frame_1_text, _rc.get_Current_Room(_player.room_id).get_Room_Ascii());
            _cc.Update_Console();
        }
    }
}
