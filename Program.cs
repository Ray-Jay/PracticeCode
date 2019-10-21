//  Date: 10-21-19
//  Chapter 31 page 201
//  Purpose: Use pattern matching with is keyword and switch statement to make methods more useful/generic

using System;
using System.Drawing;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Square mySquare = new Square(5);
            Console.WriteLine("Square Area: " + ComputeAreaWithIs(mySquare));
            Console.WriteLine("Square Area (switch): " + ComputeAreaWithSwitch(mySquare));

            Circle myCircle = new Circle(2.5);
            Console.WriteLine("Circle Area: " + ComputeAreaWithIs(myCircle));
            Console.WriteLine("Circle Area (switch): " + ComputeAreaWithSwitch(myCircle));

            Rectangle myRectangle = new Rectangle(3.5, 2);
            Console.WriteLine("Rectangle Area: " + ComputeAreaWithIs(myRectangle));
            Console.WriteLine("Rectangle Area (switch): " + ComputeAreaWithSwitch(myRectangle));

            Triangle myTriangle = new Triangle(4.5, 5);
            Console.WriteLine("Triangle Area: " + ComputeAreaWithIs(myTriangle));
            Console.WriteLine("Triangle Area (switch): " + ComputeAreaWithSwitch(myTriangle));

            Point myPoint = new Point(3);
            //Console.WriteLine("Point Area: " + ComputeAreaWithIs(myPoint));
            Console.WriteLine("Point Area (switch): " + ComputeAreaWithSwitch(myPoint));
        }

        /// <summary>
        /// Determines the input shape then computes the area using the 'is' pattern matching keyword
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>Area of Shape as double</returns>
        public static double ComputeAreaWithIs(object shape)
        {
            if (shape is Triangle t)
            {
                return t.Base * t.Height * 0.5;
            }
            else if (shape is Circle c)
            {
                return c.Radius * c.Radius * Math.PI;
            }
            else if (shape is Rectangle r)
            {
                return r.Length * r.Height;
            }
            else if (shape is Square s)
            {
                return s.Side * s.Side;
            }

            throw new ArgumentException(
                    message: $"Shape is not a recognized shape {shape.GetType()}",
                    paramName: nameof(shape));
        }

        /// <summary>
        /// Determines the input shape then computes the area using 'switch' pattern matching 
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>Area of Shape as double</returns>
        public static double ComputeAreaWithSwitch(object shape)
        {
            switch (shape)
            {
                case Triangle t:
                    return t.Base * t.Height * 0.5;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Rectangle r:
                    return r.Length * r.Height;
                case Square s:
                    return s.Side * s.Side;
                default:
                    throw new ArgumentException(
                            message: $"Shape is not a recognized shape {shape.GetType()}",
                            paramName: nameof(shape));
            }
        }
    }
}
