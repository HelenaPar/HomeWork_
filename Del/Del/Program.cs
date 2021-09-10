using System;

namespace Del
{
    class Program
    {
        //метод и делегат с одним и тем же именем
        //Random rand = new Rand 
        //{
          //Random,
          //Random,
        //};
        //создать ещё один делегат, который проходится по этому массиву, вычисляет среднее арифм.

        //private static int Random() {return 1;}
        //private delegate int Random();
        delegate int Operation(int a, int b);
        static void Main(string[] args)
        {
            while (true)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                char operation = Convert.ToChar(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                DoOperation(a, b, operation);
                Console.WriteLine();
            }
        }
        private static void DoOperation(int a, int b, char operation)
        {
            switch(operation)
            {
                case '+':
                    Operation add = (a, b) => a + b;
                    Console.WriteLine("Результат: " + add(a, b));
                    break;
                case '-':
                    Operation sub = (a, b) => a - b;
                    Console.WriteLine("Результат: " + sub(a, b));
                    break;
                case '*':
                    Operation mul = (a, b) => a * b;
                    Console.WriteLine("Результат: " + mul(a, b));
                    break;
                case '/':
                    Operation div = (a, b) =>
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Делить на ноль нельзя!");
                            return 0;
                        }
                        else return (a / b);
                    };
                    Console.WriteLine("Результат: " + div(a, b));
                    break;
                default:
                    Console.WriteLine("Не верный знак!");
                    break;
            }
        }
    }
}
