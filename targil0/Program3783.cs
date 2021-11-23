using System;

namespace Targil0
{
   partial class Program
    {
        static void Main(string[] args)
        {
            Welcome3783();
            Welcome8330();
            Console.ReadKey();
        }

        static partial void Welcome8330();
        private static void Welcome3783()
        {
            Console.Write("Enter your name: ");
            String word = Console.ReadLine();
            Console.Write(word + ", welcome to my first console application");
        }
    }
}
