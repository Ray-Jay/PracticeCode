//  Date: 10-27-19
//  Chapter 39 page 249
//  Purpose: Practice using threads. 
using System;
using System.Threading;

namespace FrogRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread frog1 = new Thread(MakeFrogJump);
            Thread frog2 = new Thread(MakeFrogJump);
            Thread frog3 = new Thread(MakeFrogJump);

            frog1.Start(222);
            frog2.Start(333);
            frog3.Start(444);

            frog1.Join();
            frog2.Join();
            frog3.Join();
        }

        public static void MakeFrogJump(object input)
        {
            int frogNumber = (int)input;
            for (int jumps = 1; jumps <= 10; jumps++)
            {
                Console.WriteLine($"Frog {frogNumber} jumped {jumps} times");
            }

            Random rand = new Random();
            Thread.Sleep(rand.Next(1001));
            Console.WriteLine($"Frog {frogNumber} finished");
        }
    }
}
