//  Date: 10-22-19
//  Chapter 33 page 213 - 215
//  Purpose: Practice creating events

using System;

namespace Events
{
    public class Program
    {
        public static void Main()
        {
            Point p = new Point();
            p.PointChanged += HandlePointChanged;
            Console.WriteLine($"({p.X},{p.Y})");
            p.X = 3;
            Console.WriteLine($"({p.X},{p.Y})");

        }

        public static void HandlePointChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Point Changed Handled");
        }
    }
}
