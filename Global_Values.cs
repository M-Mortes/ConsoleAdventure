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
        public static int seed = random.Next();
        public static Random rng = new Random(seed);
        public static int console_hight = 29;
        public static int console_width = 120;
        public static int frame_1_hight = 18;
        public static int frame_1_width = 78;
        public static int frame_2_hight = 18;
        public static int frame_2_width = 39;
        public static int frame_3_hight = 8;
        public static int frame_3_width = 118;

        public static int level { get; set;  }
        public static int gamestate { get; set; }
        public static char action_Ident { get; set; }
        public static int room_Ident { get; set; }
        public static int room_count { get; set; }
        public static List<string> frame_1_text { get; set; }
        public static List<string> frame_2_text { get; set; }
        public static List<string> frame_3_text { get; set; }
        public static List<string> actions { get; set; }
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
