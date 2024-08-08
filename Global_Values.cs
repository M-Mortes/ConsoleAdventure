using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure
{
    public static class Global_Values
    {
        private static Random random = new Random();

        public static int level { get; set;  }
        // ######################
        // 1 → exploration
        // 2 → ..
        public static int gamestate { get; set; }
        // ######################
        // 1 .. 9
        public static int action_Ident { get; set; }
        // ######################
        //    0 → deadend
        //    1 → 1-way west
        //   10 → 1-way north
        //  100 → 1-way east
        // 1000 → 1-way south
        public static int room_Ident { get; set; }

        public static int seed = random.Next();

        public static Random rng = new Random(seed);

        public static int room_count { get; set; }

        public static List<string> frame_1_text { get; set; }
        public static List<string> frame_2_text { get; set; }
        public static List<string> frame_3_text { get; set; }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
