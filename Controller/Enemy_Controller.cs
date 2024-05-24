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
        public List<String> Man()
        {
            List<String> man = [
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

        public List<String> Mage()
        {
            List<String> mage = [
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

        public List<String> Knight()
        {
            List<String> knight = [
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
