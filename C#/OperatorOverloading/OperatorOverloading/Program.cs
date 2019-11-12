//  Date: 10-22-19
//  Chapter 34 pg 222
//  Purpose: Create vector class and overload the +, -, *, / operators

using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(3, 3, 3);
            Vector v3 = new Vector(2, 0, -4);
            Vector v4 = new Vector(2, 4, 6);
            Console.WriteLine($"Vector {v1} + Vector {v2} is new Vector {v1 + v2}");
            Console.WriteLine($"Vector {v1} - Vector {v2} is new Vector {v1 - v2}");
            Console.WriteLine($"Vector {v3} negated is new Vector {-v3}");        
            Console.WriteLine($"Vector {v1} multiplied by 4 is new Vector {v1 * 4}");          
            Console.WriteLine($"Vector {v4} divided by 2 is new Vector {v4 / 2}");          
        }
    }
}
