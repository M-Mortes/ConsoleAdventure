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
        private int _hight = 29;
        private int _width = 120;
        private static int _frame_1_hight = 18;
        private static int _frame_1_width = 78;
        private static int _frame_2_hight = 18;
        private static int _frame_2_width = 39;
        private static int _frame_3_hight = 8;
        private static int _frame_3_width = 118;

        private Room_Controller _rc = new Room_Controller();

        public Console_Controller()
        {

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Console Adventure";


            // Console.CursorVisible = false;
        }

        public void generate_Enemy_View()
        {
            Enemy enemy = new Enemy();
            var _ccf = Clear_Console_Frame();

            List<string> _console_frame_1 = _ccf._console_frame_1;
            List<string> _console_frame_2 = _ccf._console_frame_2;
            List<string> _console_frame_3 = _ccf._console_frame_3;
            _console_frame_1 = Add_To_Frame(_console_frame_1, String_List_Combine(enemy.ascii, Reverse_Char(enemy.ascii), _frame_1_width));
            _console_frame_2 = String_Replace(_console_frame_2, enemy.get_stats());
            Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);
        }

        public void generate_Room_View()
        {
            var _ccf = Clear_Console_Frame();
            _rc.generate_Map(Global_Values.level);

            List<string> _console_frame_1 = _ccf._console_frame_1;
            List<string> _console_frame_2 = _ccf._console_frame_2;
            List<string> _console_frame_3 = _ccf._console_frame_3;

            Random rng = Global_Values.rng;
            _console_frame_1 = Add_To_Frame(_console_frame_1, _rc.get_Current_Room(rng.Next(_rc._rooms.Count) + 1));
            Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);
        }

        public void generate_View()
        {
            Random random = new(Global_Values.seed);
            if (random.Next(2) == 1)
            {
                generate_Enemy_View();
            }
            else
            {
                generate_Room_View();
            }
        }

        // #####################################
        // #####################################
        // Emptys the view
        private (List<string> _console_frame_1, List<string> _console_frame_2, List<string> _console_frame_3) Clear_Console_Frame()
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
        private void Update_Console(List<string> _console_frame_1, List<string> _console_frame_2, List<string> _console_frame_3)
        {
            string _full = new('#', _width);

            List<string> temp = [
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20"
                ];

            _console_frame_1 = String_Replace(_console_frame_1);
            _console_frame_2 = String_Replace(_console_frame_2);
            _console_frame_3 = String_Replace(_console_frame_3);

            Console.WriteLine(_full);
            for (int i = 0; i < _console_frame_1.Count(); i++)
            {
                Console.WriteLine("#" + _console_frame_1[i] + "#" + _console_frame_2[i] + "#");
            }
            Console.WriteLine(_full);
            foreach (var str in _console_frame_3)
            {
                Console.WriteLine("#" + str + "#");
            }
            Console.WriteLine(_full);
        }

        // #####################################
        // #####################################
        // replacing the stringplaceholders
        private List<string> String_Replace(List<string> _string_list, List<string>? text = null)
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
        private List<string> String_List_Combine(List<string> _left, List<string> _right, int _width = 0)
        {
            List<string> _list = new List<string>();
            List<string> _list_left = new List<string>();
            List<string> _list_right = new List<string>();
            int max_size = _left.Count >= _right.Count ? _left.Count : _right.Count;
            if (_left.Count < max_size)
            {
                for (int i = _left.Count; i <= max_size; i++)
                    _left.Append<string>(new string(' ', _left[0].Length)).ToList();
            }
            else if (_right.Count < max_size)
            {
                for (int i = _right.Count; i <= max_size; i++)
                    _right.Append<string>(new string(' ', _right[0].Length)).ToList();
            }
            _list_right = _right;
            _list_left = _left;

            if (_width == 0)
            {
                int max_left = 0;
                foreach (string str in _left)
                {
                    if (str.Length > max_left)
                    {
                        max_left = str.Length;
                    }
                }
                for (int i = 0; i < max_size; i++)
                {
                    _list.Add(_left[i] + new string(' ', 1 + max_left - _left[i].Length) + _right[i]);
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
        private List<string> Add_To_Frame(List<string> string_list, List<string> to_add)
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
        private List<string> Reverse_Char(IEnumerable<string> figure)
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
    }

}
