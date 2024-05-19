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
        public static IEnumerable<String> Man()
        {
            IEnumerable<String> man = [
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

        public static IEnumerable<String> Mage()
        {
            IEnumerable<String> mage = new List<string> {
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
                "/_/       \\||  " };
            return mage;
        }

        public static IEnumerable<String> Knight()
        {
            IEnumerable<String> knight = [
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
