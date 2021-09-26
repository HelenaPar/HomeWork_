using System;

namespace Del3
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            stopwatch.Event += Handler1;
            stopwatch.Event += Handler2;

            stopwatch.InitializeEvent();

            Console.ReadKey();
        }
        private static void Handler1(object obj, EventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.ToString());
        }
        private static void Handler2(object obj, EventArgs eventArgs)
        {
            var messageEventArgs = eventArgs as MessageEventArgs;
            if (messageEventArgs == null)
            {
                return;
            }

            if (messageEventArgs.Second != 0)
            {
                Console.WriteLine("Прошло(-а) " + messageEventArgs.Second + " секунд(-а)");
            }
            else
            {
                Console.WriteLine("Секундомер сломался");
            }
        }
    }
}

