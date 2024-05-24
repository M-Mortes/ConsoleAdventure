using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System;

namespace ConsoleAdventure.Controller
{
    class Console_Controller
    {
        int _hight = 29;
        int _width = 120;
        private static int _frame_1_width = 78;
        private static int _frame_1_hight = 18;
        private static int _frame_2_hight = 18;
        private static int _frame_2_width = 39;
        private static int _frame_3_hight = 8;
        private static int _frame_3_width = 118;
        private static int action_ident;

        static void Main(string[] args)
        {

            var _cc = new Console_Controller();
            var _rc = new Room_Controller();
            var _ec = new Enemy_Controller();
            var _ccf = _cc.Clear_Console_Frame();

            List<String> _console_frame_1 = _ccf._console_frame_1;
            List<String> _console_frame_2 = _ccf._console_frame_2;
            List<String> _console_frame_3 = _ccf._console_frame_3;

            List<String> mage = _ec.Mage();
            Random random = new Random();

            _console_frame_1 = _cc.Add_To_Frame(_console_frame_1, _cc.Frame_Combine(mage, _cc.Reverse_Char(mage), _frame_1_width));
            _cc.Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);
            Console.Title = "Fixed Size Console";
            Console.Write("Nächste aktion?: ");
            action_ident = Console.Read();

            _console_frame_1 = _ccf._console_frame_1;
            _console_frame_2 = _ccf._console_frame_2;
            _console_frame_3 = _ccf._console_frame_3;


            _console_frame_1 = _cc.Add_To_Frame(_console_frame_1, _rc.Generate_Room(random.Next(2) == 1, random.Next(2) == 1, random.Next(2) == 1, random.Next(2) == 1));
            _cc.Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Console.CursorVisible = false;
            // string name = Console.ReadLine();
            // Console.WriteLine($"Hallo, {name}! Schön, Sie kennenzulernen.");
            // Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden...");
        }

        // #####################################
        // #####################################
        (List<String> _console_frame_1, List<String> _console_frame_2, List<String> _console_frame_3) Clear_Console_Frame()
        {

            List<String> _console_frame_1 = new List<string>();
            List<String> _console_frame_2 = new List<string>();
            List<String> _console_frame_3 = new List<string>();

            for (int i = 0; i < _frame_1_hight; i++)
                _console_frame_1.Add(new String(' ', _frame_1_width));
            for (int i = 0; i < _frame_2_hight; i++)
                _console_frame_2.Add(new String(' ', _frame_2_width));
            for (int i = 0; i < _frame_3_hight; i++)
                _console_frame_3.Add(new String(' ', _frame_3_width));
            return (_console_frame_1, _console_frame_2, _console_frame_3);
        }

        // #####################################
        // #####################################
        void Update_Console(List<String> _console_frame_1, List<String> _console_frame_2, List<String> _console_frame_3)
        {
            string _full = new string('#', _width);

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
        private List<String> String_Replace(List<String> _string_list, List<String>? text = null)
        {
            if (text != null)
            {
                int index = 0;
                foreach (String str in _string_list)
                {
                    int i = 0;
                    char[] chars = str.ToCharArray();
                    char[] new_chars = [];
                    foreach (char _char in chars)
                    {
                        if (_char == 'X' && text[index].Length > i)
                            new_chars.Append(text[index][i]);
                        else
                            new_chars.Append(_char);
                        i++;
                    };
                    index++;
                }
            }
            return _string_list.Select(x => x.Replace('X', ' ')).ToList();
        }

        // #####################################
        // #####################################
        private List<String> Frame_Combine(List<String> _left, List<String> _right, int _width)
        {
            List<String> _list = new List<String>();
            List<String> _list_left = new List<String>();
            List<String> _list_right = new List<String>();
            int max_size = _left.Count() >= _right.Count() ? _left.Count() : _right.Count();
            if (_left.Count() < max_size)
            {
                _list_left = _left.Prepend<String>(new String(' ', _left[0].Length)).ToList();
                _list_right = _right;
            }
            else if (_right.Count() < max_size)
            {
                _list_right = _right.Prepend<String>(new String(' ', _right[0].Length)).ToList();
                _list_left = _left;
            }
            else
            {
                _list_right = _right;
                _list_left = _left;
            }
            for (int i = 0; i < max_size; i++)
            {
                _list.Add(_list_left[i] + new String(' ', _width - 10 - (_list_left[i].Length + _list_right[i].Length)) + _list_right[i]);
            }
            return _list;
        }

        // #####################################
        // #####################################
        // Adds the Ascii List to the show list
        // #####################################
        // #####################################
        private List<String> Add_To_Frame(List<String> string_list, List<String> to_add)
        {
            int index = 0;
            int index_count = 0;
            int top = (string_list.Count() - to_add.Count()) / 2;
            int bot = string_list.Count() - to_add.Count() - top;
            int start = (string_list[0].Length / 2 - to_add[0].Length / 2);
            List<String> new_string_list = new List<string>();
            foreach (String str in string_list)
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
        // ############################
        // ############################
        public List<String> Reverse_Char(IEnumerable<String> figure)
        {
            List<String> new_string = new List<String>();
            foreach (String str in figure)
            {
                String s = str.Replace('\\', 'x').Replace('/', '\\').Replace('x', '/');
                s = s.Replace('[', 'x').Replace(']', '[').Replace('x', ']');
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                new_string.Add(new String(charArray));
            }
            return new_string;
        }
    }
}
