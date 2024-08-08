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
        // ###########
        // 1 → ..
        // 2 → ..
        public static int gamestate { get; set; }
        // ######################
        // 1 .. 9
        public static int action_Ident { get; set; }
        // ######################
        //    0 → deadend
        //    1 → 1-way west
        //   10 → 1-way north
        //   11 → 2-way west-north
        //  100 → 1-way east
        //  101 → 2-way west-east
        //  110 → 2-way north-east
        //  111 → 3-way west-north-east
        // 1000 → 1-way south
        // 1001 → 2-way west-south
        // 1010 → 2-way north-south
        // 1011 → 3-way west-north-south
        // 1100 → 2-way east-south
        // 1101 → 3-way west-east-south
        // 1110 → 3-way north-south-east
        // 1111 → 4-way north-south-east-west
        public static int room_Ident { get; set; }

        public static int seed = random.Next();

        public static Random rng = new Random(seed);

        public static int room_count { get; set; }


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
