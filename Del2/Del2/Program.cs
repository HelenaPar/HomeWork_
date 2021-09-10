using System;

namespace Del2
{
    
    class Program
    {
        private delegate int RandomNum();
        private delegate int Calc(RandomNum[] array);
        static void Main(string[] args)
        {
            RandomNum[] random = new RandomNum[]
            {
                Randomize,
                Randomize,
                Randomize,
                Randomize,
                Randomize,
            };

            for(int i = 0; i < random.Length; i++)
            {
                Console.WriteLine(random[i]());
            }
            Calc calc = delegate (RandomNum[] array)
            {
                int summ = 0;
                int kol = 0;
                for(int i = 0; i < array.Length; i++)
                {
                    summ += array[i]();
                    kol++;
                }
                return ((summ)/(kol));
            };
            Console.WriteLine();
            Console.WriteLine(calc(random));
            Console.ReadKey();
        }
        public static Random rnd = new Random();
        public static int Randomize()
        {
            return rnd.Next(1, 10);
        }
    }
}
