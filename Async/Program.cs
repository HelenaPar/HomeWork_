using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            CreditCalculator calculator = new CreditCalculator();
            Stopwatch sw = Stopwatch.StartNew();
            CreditInfo info = await calculator.Calculate();

            Console.WriteLine($"Время загрузки: {sw.Elapsed}");
            Console.WriteLine(info);
            Console.ReadKey();
        }
    }
}
