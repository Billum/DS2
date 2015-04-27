using System;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] input = s.Split(' ');

            long[] alfa = new long[] {14, 1, 0, 22, 23, 24, 10000};
            long x = Int64.Parse(input[0]);
            long beta = Int64.Parse(input[1]);
            int gamma = int.Parse(input[2]);

            //for (int i = 0; i < alfa.Length; i++)
            //{
            //    alfa[i] = Int64.Parse(Console.ReadLine());
            //}

            Levels[] levels = makeLevels(x, beta, gamma);

            for (int i = 0; i < alfa.Length; i++)
            {
                findLevel(levels, alfa[i], gamma);
            }
        }
        static Levels[] makeLevels(long x, long beta, int gamma)
        {
            Levels[] level = new Levels[gamma];
            level[0] = new Levels(0, (int)x - 1);
            int i = 0;

            while (i < gamma - 1)
            {
                double c = ceiling((double)(x) / (double)(beta));

                level[i + 1] = new Levels((int)x, (int)(x + c) - 1);
                x = (int)(x + c);
                i++;
            }
            return level;
        }
        static void findLevel(Levels[] levels, long alfa, long gamma)
        {
            for (int i = 0; i < gamma; i++)
            {
                if (alfa >= levels[i].begin && alfa <= levels[i].eind)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
                else if (alfa > levels[gamma - 1].eind)
                {
                    Console.WriteLine(gamma);
                    break;
                }
            }
        }
        public static int ceiling(double x)
        {
            if (x != (int)x)
            {
                string y = x.ToString();
                string[] split = y.Split('.');

                long integr = Int64.Parse(split[0]);
                long deciml = Int64.Parse(split[1]);

                if (deciml != 0)
                    return (int)integr + 1;
                else
                    return (int)integr;
            }
            else
                return (int)x;
        }
        public static int binsearch(int[] A, int key, int min, int max)
        {
            if (max < min)
                return -1;
            else
            {
                int mid = (min + max) / 2;
                if (A[mid] > key)
                    return binsearch(A, key, min, mid - 1);
                else if (A[mid] < key)
                    return binsearch(A, key, mid + 1, max);
                else
                    return mid;
            }
        }
    }
    class Levels
    {
        public int begin;
        public int eind;
        public Levels(int begin, int eind)
        {
            this.begin = begin;
            this.eind = eind;
        }
    }
}
