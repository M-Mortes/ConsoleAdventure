using ConsoleAdventure.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleAdventure.Controller
{
    internal class Console_Controller
    {
        private static Player _player;
        private static int _hight = Global_Values.console_hight;
        private static int _width = Global_Values.console_width;
        private static int _frame_1_hight = Global_Values.frame_1_hight;
        private static int _frame_1_width = Global_Values.frame_1_width;
        private static int _frame_2_hight = Global_Values.frame_2_hight;
        private static int _frame_2_width = Global_Values.frame_2_width;
        private static int _frame_3_hight = Global_Values.frame_3_hight;
        private static int _frame_3_width = Global_Values.frame_3_width;

        private (List<string> _console_frame_1, List<string> _console_frame_2, List<string> _console_frame_3) _ccf;

        private Room_Controller _rc;

        public Console_Controller(Player player, Room_Controller rc)
        {
            _player = player;
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Console Adventure";
            _ccf = Clear_Console_Frame();
            _rc = rc;
        }

        // #####################################
        // #####################################
        // Emptys the view
        public (List<string> _console_frame_1, List<string> _console_frame_2, List<string> _console_frame_3) Clear_Console_Frame()
        {
            List<string> _console_frame_1 = new();
            List<string> _console_frame_2 = new();
            List<string> _console_frame_3 = new();

            for (int i = 0; i < _frame_1_hight; i++)
                _console_frame_1.Add(new string(' ', _frame_1_width));
            for (int i = 0; i < _frame_2_hight; i++)
            {
                if (i == 0 || i == _frame_2_hight - 1)
                    _console_frame_2.Add(new string(' ', _frame_2_width));
                else
                    _console_frame_2.Add(new string(' ', 1) + new string('X', _frame_2_width - 2) + new string(' ', 1));
            }
            for (int i = 0; i < _frame_3_hight; i++)
                if (i == 0 || i == _frame_3_hight - 1)
                    _console_frame_3.Add(new string(' ', _frame_3_width));
                else
                    _console_frame_3.Add(new string(' ', 1) + new string('X', _frame_3_width - 2) + new string(' ', 1));
            return (_console_frame_1, _console_frame_2, _console_frame_3);
        }

        // #####################################
        // #####################################
        // writes the view with spacers
        public void Update_Console()
        {
            _update_Actions();
            List<string> actions = Global_Values.actions;
            actions.Add("(q) Quit");

            string _full = new('#', _width);

            Global_Values.frame_1_text = String_Replace(Global_Values.frame_1_text);
            Global_Values.frame_2_text = String_Replace(Global_Values.frame_2_text);
            Global_Values.frame_3_text = String_Replace(Global_Values.frame_3_text, actions);

            Console.WriteLine(_full);
            for (int i = 0; i < Global_Values.frame_1_text.Count(); i++)
            {
                Console.WriteLine("#" + Global_Values.frame_1_text[i] + "#" + Global_Values.frame_2_text[i] + "#");
            }
            Console.WriteLine(_full);
            foreach (var str in Global_Values.frame_3_text)
            {
                Console.WriteLine("#" + str + "#");
            }
            Console.Write(_full);
        }

        // #####################################
        // #####################################
        // replacing the stringplaceholders
        public List<string> String_Replace(List<string> _string_list, List<string>? text = null)
        {
            if (text != null)
            {
                int lines = _string_list.Count - 2;
                if (text.Count > lines)
                {
                    List<string> list = text;
                    text = new();
                    int max = ((int)Math.Ceiling((double)list.Count / lines)) * lines;
                    text = list.GetRange(0, lines);
                    for (int i = list.Count; i <= max; i++)
                        list.Add("");
                    for (int i = lines; i < max; i += lines)
                    {
                        text = String_List_Combine(text, list.GetRange(i, lines));
                    }
                }
                List<string> result = new List<string>();
                int index = 0;
                foreach (string str in _string_list)
                {
                    if (!str.Contains('X'))
                    {
                        result.Add(str);
                        continue;
                    }
                    if (index >= text.Count)
                    {
                        result.Add(str.Replace('X', ' '));
                        continue;
                    }
                    int i = 0;
                    char[] chars = str.ToCharArray();
                    string new_chars = "";
                    foreach (char _char in chars)
                    {
                        if (_char == 'X' && text[index].Length > i)
                        {
                            new_chars += text[index][i];
                            i++;
                        }
                        else
                            new_chars += _char == 'X' ? ' ' : _char;
                    };
                    index++;
                    result.Add(new_chars);
                }
                return result;
            }
            return _string_list.Select(x => x.Replace('X', ' ')).ToList();
        }

        // #####################################
        // #####################################
        // combines 2 string lists, centers them
        public List<string> String_List_Combine(List<string> _left, List<string> _right, int _width = 0)
        {
            List<string> _list = new List<string>();
            List<string> _list_left = new List<string>();
            List<string> _list_right = new List<string>();
            int max_size = _left.Count >= _right.Count ? _left.Count : _right.Count;
            _list_right = _right;
            _list_left = _left;
            if (_list_left.Count < max_size)
            {
                for (int i = _list_left.Count; i < max_size; i++)
                    _list_left = _list_left.Prepend(new string(' ', _list_left[0].Length)).ToList();
            }
            else if (_list_right.Count < max_size)
            {
                for (int i = _list_right.Count; i < max_size; i++)
                    _list_right = _list_right.Prepend(new string(' ', _list_right[0].Length)).ToList();
            }

            if (_width == 0)
            {
                int max_left = 0;
                foreach (string str in _list_left)
                    if (str.Length > max_left)
                        max_left = str.Length;
                for (int i = 0; i < max_size; i++)
                {
                    _list.Add(_list_left[i] + new string(' ', 1 + max_left - _list_left[i].Length) + _list_right[i]);
                }
            }
            else
            {
                for (int i = 0; i < max_size; i++)
                {
                    _list.Add(_list_left[i] + new string(' ', _width - 10 - (_list_left[i].Length + _list_right[i].Length)) + _list_right[i]);
                }
            }
            return _list;
        }

        // #####################################
        // #####################################
        // Adds the Ascii List to the show list
        public List<string> Add_To_Frame(List<string> string_list, List<string> to_add)
        {
            int index = 0;
            int index_count = 0;
            int top = (string_list.Count() - to_add.Count()) / 2;
            int bot = string_list.Count() - to_add.Count() - top;
            int start = (string_list[0].Length / 2 - to_add[0].Length / 2);
            List<string> new_string_list = new List<string>();
            foreach (string str in string_list)
            {
                if (index >= top && index < string_list.Count() - bot)
                {
                    var string_builder = new StringBuilder(str);
                    string_builder.Remove(start, to_add[index_count].Length);
                    string_builder.Insert(start, to_add[index_count]);
                    new_string_list.Add(string_builder.ToString());
                    index_count++;
                }
                else
                {
                    new_string_list.Add(str);
                }
                index++;
            }
            return new_string_list;
        }

        // ############################
        // ############################
        // Mirror the given ascii List
        public List<string> Reverse_Char(IEnumerable<string> figure)
        {
            List<string> new_string = new List<string>();
            foreach (string str in figure)
            {
                string s = str.Replace('\\', 'x').Replace('/', '\\').Replace('x', '/');
                s = s.Replace('[', 'x').Replace(']', '[').Replace('x', ']');
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                new_string.Add(new string(charArray));
            }
            return new_string;
        }

        public List<string> generate_Status_Table(List<string> enemy_stat)
        {
            List<string> player_stat = _player.get_stats();
            List<string> stat_table = new();
            string player_txt = "Player";
            string enemy_txt = "Enemy";
            int max_len = 0;
            foreach (string str in player_stat)
                if (str.Length > max_len)
                    max_len = str.Length;
            foreach (string str in enemy_stat)
                if (str.Length > max_len)
                    max_len = str.Length;
            stat_table.Add(new string(' ', (max_len + 1) / 2 - player_txt.Length / 2) + player_txt + new string(' ', (max_len + 1) / 2 - player_txt.Length / 2) +
                '|' + new string(' ', (max_len + 1) / 2 - enemy_txt.Length / 2) + enemy_txt + new string(' ', (max_len) / 2 - enemy_txt.Length / 2));
            stat_table.Add(new string('-', max_len + 1) + '|' + new string('-', max_len + 1));
            for (int i = 0; i < player_stat.Count; i++)
            {
                stat_table.Add(new string(' ', max_len - player_stat[i].Length) + player_stat[i] + " | " + enemy_stat[i]);
            }
            return stat_table;
        }

        private void _update_Actions()
        {
            int gamestate = Global_Values.gamestate;
            List<string> actions = new();
            // idle
            if (gamestate == 0)
            {
            }
            // exploration
            else if (gamestate == 1)
            {
                Room room = _rc.get_Current_Room(_player.room_id);
                var rooms = _rc.get_Neighbors(room);
                List<Room> neighbors = [rooms.north, rooms.south, rooms.west, rooms.east];
                bool north_visit = false;
                bool south_visit = false;
                bool west_visit = false;
                bool east_visit = false;
                foreach (Room _room in neighbors)
                {
                    if (_room == null)
                        continue;
                    if (room.x + 1 == _room.x && _room.visited)
                        east_visit = true;
                    if (room.x - 1 == _room.x && _room.visited)
                        west_visit = true;
                    if (room.y + 1 == _room.y && _room.visited)
                        north_visit = true;
                    if (room.y - 1 == _room.y && _room.visited)
                        south_visit = true;
                }
                if (!room.north_block)
                    actions.Add("(w) Go north" + (north_visit ? " (visited)" : ""));
                if (!room.south_block)
                    actions.Add("(s) Go south" + (south_visit ? " (visited)" : ""));
                if (!room.west_block)
                    actions.Add("(a) Go west" + (west_visit ? " (visited)" : ""));
                if (!room.east_block)
                    actions.Add("(d) Go east" + (east_visit ? " (visited)" : ""));
                actions.Add("...");
            }
            // ..
            else if (gamestate == 2)
            {

            }
            Global_Values.actions = actions;
        }
    }
}
