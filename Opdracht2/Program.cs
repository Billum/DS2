using System;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] input = s.Split(' ');
            long x = Int64.Parse(input[0]);
            long beta = Int64.Parse(input[1]);
            int gamma = int.Parse(input[2]);

            Levels[] levels = makeLevels(x, beta, gamma);

            string alpha = Console.ReadLine();

            while( alpha != null)
            {
                Console.WriteLine(binsearch(levels, Int64.Parse(alpha), 0, levels.Length - 1));
                alpha = Console.ReadLine();
            }
        }
        public static Levels[] makeLevels(long x, long beta, int gamma)
        {
            Levels[] level = new Levels[gamma];
            level[0] = new Levels(0, x);

            for (int i = 1; i < gamma; i++)
            {
                long c = ceiling(x, beta);

                level[i] = new Levels(x, x + c);
                x = x + c;
            }
            return level;
        }
        public static long ceiling(long x, long beta)
        {
            if (x % beta == 0)
                return x / beta;
            else
                return (x / beta) + 1;
        }
        public static int binsearch(Levels[] A, long key, int min, int max)
        {
            if (max < min)
                return A.Length;         
            else
            {
                int mid = (min + max) / 2;

                if (A[mid].begin <= key && key < A[mid].eind)
                    return mid + 1;
                else if (A[mid].begin > key)
                    return binsearch(A, key, min, mid - 1);
                else if (A[mid].eind <= key)
                    return binsearch(A, key, mid + 1, max);
                else
                    return -1;
            }
        }
    }
    class Levels
    {
        public long begin;
        public long eind;
        public Levels(long begin, long eind)
        {
            this.begin = begin;
            this.eind = eind;
        }
    }
}

// Tomas Billum
// 4161882
