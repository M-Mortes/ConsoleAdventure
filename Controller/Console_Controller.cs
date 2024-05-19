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

        int _septerator_space = 80;

        static void Main(string[] args)
        {
            int _frame_1_hight = 18;
            int _frame_1_width = 78;
            int _frame_2_hight = 18;
            int _frame_2_width = 39;
            int _frame_3_hight = 8;
            int _frame_3_width = 118;

            var _cc = new Console_Controller();
            var _rc = new Room_Controller();
            var _ec = new Enemy_Controller();

            List<String> _console_frame_1 = new List<string>();
            List<String> _console_frame_2 = new List<string>();
            List<String> _console_frame_3 = new List<string>();

            for (int i = 0; i < _frame_1_hight; i++)
                _console_frame_1.Add(new String(' ', _frame_1_width));
            for (int i = 0; i < _frame_2_hight; i++)
                _console_frame_2.Add(new String(' ', _frame_2_width));
            for (int i = 0; i < _frame_3_hight; i++)
                _console_frame_3.Add(new String(' ', _frame_3_width));

            _console_frame_1 = _cc.Add_Char(_console_frame_1, _cc.Frame_Combine(_ec.Mage().ToList(), _cc.Reverse_Char(_ec.Mage), _frame_1_width));
            _cc.Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);
            _console_frame_1 = _cc.Add_Char(_console_frame_1, _rc.Generate_Room(true, true, true, false));
            _cc.Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Console.CursorVisible = false;
            // Console.Title = "Fixed Size Console";
            // Console.Write("Bitte geben Sie Ihren Namen ein: ");
            // string name = Console.ReadLine();
            // Console.WriteLine($"Hallo, {name}! Schön, Sie kennenzulernen.");
            // Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden...");
            // Console.ReadKey();
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
        private List<String> String_Replace(List<String> _string_list)
        {
            return _string_list.Select(x => x.Replace('X', ' ')).ToList();
        }

        // #####################################
        // #####################################
        private List<String> Frame_Combine(IEnumerable<String> _left, IEnumerable<String> _right, int _width)
        {
            List<String> _list = new List<String>();
            List<String> _list_left = new List<String>();
            List<String> _list_right = new List<String>();
            int max_size = _left.Count() >= _right.Count() ? _left.Count() : _right.Count();
            if (_left.Count() < max_size){
                _list_left = _left.Prepend<String>(new String(' ', _left.ToList()[0].Length)).ToList();
                _list_right = _right.ToList();
            }
            else if (_right.Count() < max_size){
                _list_right = _right.Prepend<String>(new String(' ', _right.ToList()[0].Length)).ToList();
                _list_left = _left.ToList();
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
        private List<String> Add_Char(List<String> string_list, List<String> to_add)
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
        public IEnumerable<String> Reverse_Char(List<String> figure)
        {
            IEnumerable<String> new_string = new List<String>();
            foreach (String str in figure)
            {
                String s = str.Replace('\\', 'x').Replace('/', '\\').Replace('x', '/');
                s = s.Replace('[', 'x').Replace(']', '[').Replace('x', ']');
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                new_string.Append(new string(charArray));
            }
            return new_string;
        }
    }
}
