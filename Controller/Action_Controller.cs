using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Controller
{

    internal class Action_Controller
    {

        public void next_Action()
        {
            Console.Write("Nächste aktion?: ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar.Equals('q'))
            {
                Console.WriteLine("\n\rAre you sure that you want to exit? y/n");
                if (Console.ReadKey().KeyChar.Equals('y'))
                {
                    Environment.Exit(0);
                }
                else
                {
                    next_Action();
                    return;
                }

            }
            else if (char.IsDigit(key.KeyChar) && key.KeyChar >= '1' && key.KeyChar <= '9')
            {
                Global_Values.action_Ident = Int32.Parse(key.KeyChar.ToString());
            }
            else
            {
                Console.WriteLine("\n\rInvalid input");
                next_Action();
                return;
            }

        }

        public void next_Reaction()
        {
            int gamestate = Global_Values.gamestate;
            int ident = Global_Values.action_Ident;
            switch (gamestate)
            {
                case 1:
                    break;
            }
        }

        private void ident_action_walk(int ident)
        {
            switch (ident)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }
        }
    }
}
