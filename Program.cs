using System;

namespace delagates
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine(new Task1().getArifmeticSum(2, -1000, 8));
        }
        static void Task2()
        {
            Console.WriteLine(new Task2().Start());
        }
        static void Task3()
        {
            while (true)
            {
                new Task3(Console.ReadLine());
            }
        }
        static void Main()
        {
            //Task1();
            //Task2();
            Task3();
        }
    }
}
