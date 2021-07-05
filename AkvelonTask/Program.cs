using System;

namespace AkvelonTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BalanceVerificator verificator = new BalanceVerificator();
            Console.WriteLine("Write brackets:");
            while(true)
            {
                string bracketsString = Console.ReadLine();
                PrintResult(verificator.IsBalancedBracketsString(bracketsString));
                verificator = new BalanceVerificator();
            }
        }

        static void PrintResult(int result)
        {
            switch (result)
            {
                case -2:
                    break;
                case -1:
                    Console.WriteLine("BALANCED, returns -1");
                    break;
                default:
                    Console.WriteLine("NOT BALANCED ({0}), returns {0}", result + 1);
                    break;
            }
        }

    }
}
