using System;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] input = s.Split(' ');
            int[] alfa = new int[7];
            int num_lines = alfa.Length;
            long level = 0;

            long x = Int64.Parse(input[0]);
            long beta = Int64.Parse(input[1]);
            long gamma = Int64.Parse(input[2]);

            for (int i = 0; i < num_lines; i++ )
            {
                alfa[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < num_lines; i++)
            {
                level = 1;
                x = Int64.Parse(input[0]);

                while (alfa[i] >= x && level < gamma)
                {
                    double c = ceiling((double)(x) / (double)(beta));

                    x = (int)(x + c);
                    level++;
                }
                Console.WriteLine(level);
            }
        }

        public static int ceiling(double x)
        {
            if (x != (int)x)
            {
                string y = x.ToString();
                string[] split = y.Split('.');

                int integr = int.Parse(split[0]);
                int deciml = int.Parse(split[1]);

                if (deciml != 0)
                    return integr + 1;
                else
                    return integr;
            }
            else
                return (int)x;
        }
    }
}
