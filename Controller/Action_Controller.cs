using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Controller
{

    internal class Action_Controller
    {
        public int action_ident;

        public void next_Action()
        {
            Console.Write("Nächste aktion?: ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar.Equals('q'))
            {
                Environment.Exit(0);
            }
            else if (char.IsDigit(key.KeyChar) && key.KeyChar >= '1' && key.KeyChar <= '9')
            {
                Global_Values.action_ident = Int32.Parse(key.KeyChar.ToString());
            }
            else
            {
                Console.WriteLine("\n\rInvalid input");
                next_Action();
                return;
            }

        }
    }
}
