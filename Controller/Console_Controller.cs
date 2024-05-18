using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

            var _console_controller = new Console_Controller();
            List<String> _console_frame_1 = new List<string>();
            List<String> _console_frame_2 = new List<string>();
            List<String> _console_frame_3 = new List<string>();

            for (int i = 0; i < _frame_1_hight; i++)
                _console_frame_1.Add(new String(' ', _frame_1_width));
            for (int i = 0; i < _frame_2_hight; i++)
                _console_frame_2.Add(new String(' ', _frame_2_width));
            for (int i = 0; i < _frame_3_hight; i++)
                _console_frame_3.Add(new String(' ', _frame_3_width));

            List<String> man = [
                "     ____        ",
                "    /    \\      ",
                "   /      |      ",
                "   \\      |     ",
                "    \\____/      ",
                "     /   \\      ",
                "    / / \\ \\    ",
                "   / /| |\\ \\   ",
                "  / / | | \\ \\  ",
                " /_/  | |  \\_\\ ",
                "      | |        ",
                "     _|_|_       ",
                "    / / \\ \\    ",
                "   / /   \\ \\   ",
                "  / /     \\ \\  ",
                " /_/       \\_\\ "];

            List<String> mage = [
                "     ____         ",
                "  __/    \\__     ",
                " /__________\\    ",
                "   /      | __    ",
                "   \\      |/  \\ ",
                "    \\____/ |  |  ",
                "     /   \\ \\||/ ",
                "    / / \\ \\ ||  ",
                "   / /| |\\ \\||  ",
                "  / / | | \\ ||   ",
                " /_/  | |  \\||   ",
                "      | |   ||    ",
                "     _|_|_  ||    ",
                "    / / \\ \\ ||  ",
                "   / /   \\ \\||  ",
                "  / /     \\ ||   ",
                " /_/       \\||   "];

            List<String> knight = [
                "          ____          ",
                "         /    \\        ",
                "        /      \\       ",
                "        \\      /       ",
                "         \\____/        ",
                "         [/   \\]  /\\  ",
                "   ____ [/ / \\ \\] ||  ",
                "  /    \\/ /| |\\ \\]|| ",
                " /      \\/[| |]\\ \\|| ",
                " \\      / [| |] \\ ||  ",
                "  \\____/  [| |]  \\II  ",
                "         [_|_|_]  II    ",
                "         / / \\ \\      ",
                "        / /   \\ \\     ",
                "       / /     \\ \\    ",
                "      /_/       \\_\\   "];

            _console_frame_1 = _console_controller.Add_Char(_console_frame_1, mage);
            _console_frame_1 = _console_controller.Add_Char(_console_frame_1, _console_controller.Reverse_Char(knight), true);
            _console_controller.Update_Console(_console_frame_1, _console_frame_2, _console_frame_3);

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

        private List<String> String_Replace(List<String> _string_list)
        {
            return _string_list.Select(x => x.Replace('X', ' ')).ToList();
        }

        private List<String> Add_Char(List<String> string_list, List<String> to_add, bool right = false)
        {
            int start;

            int index = 0;
            int index_count = 0;
            int top = (string_list.Count() - to_add.Count()) / 2;
            int bot = string_list.Count() - to_add.Count() - top;
            List<String> new_string_list = new List<string>();
            foreach (String str in string_list)
            {
                if (index >= top && index < string_list.Count() - bot)
                {
                    if (right)
                    {
                        start = str.Length - 2 - to_add[index_count].Length;
                        /*
                        start = str.Length - to_add[index_count].Length;
                        if (to_add[index_count].Contains('\\'))
                        {
                            start -= 1 * to_add[index_count].Count(x => x == '\\');
                        }
                        */
                    }
                    else
                        start = 2;
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
        public List<String> Reverse_Char(List<String> man)
        {
            List<String> new_string = new List<String>();
            foreach (String str in man)
            {
                String s = str.Replace('\\', 'x').Replace('/', '\\').Replace('x', '/');
                s = s.Replace('[', 'x').Replace(']', '[').Replace('x', ']');
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                new_string.Add(new string(charArray));
            }
            return new_string;
        }
    }
}
