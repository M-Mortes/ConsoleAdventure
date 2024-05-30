using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Controller
{
    /*
     * "    ____     ",
     * "   /    \    ",
     * "  /      |   ",
     * "  \      |   ",
     * "   \____/    ",
     * "    /   \    ",
     * "   / / \ \   ",
     * "  / /| |\ \  ",
     * " / / | | \ \ ",
     * "/_/  | |  \_\",
     * "     | |     ",
     * "    _|_|_    ",
     * "   / / \ \   ",
     * "  / /   \ \  ",
     * " / /     \ \ ",
     * "/_/       \_\" 
     */
    internal class Enemy_Controller
    {
        public List<string> Man()
        {
            List<string> man = [
                "    ____       ",
                "   /    \\     ",
                "  /      |     ",
                "  \\      |    ",
                "   \\____/     ",
                "    /   \\     ",
                "   / / \\ \\   ",
                "  / /| |\\ \\  ",
                " / / | | \\ \\ ",
                "/_/  | |  \\_\\",
                "     | |       ",
                "    _|_|_      ",
                "   / / \\ \\   ",
                "  / /   \\ \\  ",
                " / /     \\ \\ ",
                "/_/       \\_\\"];
            return man;
        }

        public List<string> Mage()
        {
            List<string> mage = [
                "    ____        ",
                " __/    \\__    ",
                "/__________\\   ",
                "  /      | __   ",
                "  \\      |/  \\",
                "   \\____/ |  | ",
                "    /   \\ \\||/",
                "   / / \\ \\ || ",
                "  / /| |\\ \\|| ",
                " / / | | \\ ||  ",
                "/_/  | |  \\||  ",
                "     | |   ||   ",
                "    _|_|_  ||   ",
                "   / / \\ \\ || ",
                "  / /   \\ \\|| ",
                " / /     \\ ||  ",
                "/_/       \\||  " ];
            return mage;
        }

        public List<string> Knight()
        {
            List<string> knight = [
                "         ____         ",
                "        /    \\       ",
                "       /      \\      ",
                "       \\      /      ",
                "        \\____/       ",
                "        [/   \\]  /\\ ",
                "  ____ [/ / \\ \\] || ",
                " /    \\/ /| |\\ \\]||",
                "/      \\/[| |]\\ \\||",
                "\\      / [| |] \\ || ",
                " \\____/  [| |]  \\II ",
                "        [_|_|_]  II   ",
                "        / / \\ \\     ",
                "       / /   \\ \\    ",
                "      / /     \\ \\   ",
                "     /_/       \\_\\  "];
            return knight;
        }
    }
}
