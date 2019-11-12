using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorOverloading
{
    class Vector
    {
        //  properties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //  constructor
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //  overloaded operations
        //  add
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector (v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        
        //  subtract
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        //  negate
        public static Vector operator -(Vector v1)
        {
            Vector newV = new Vector(-v1.X, -v1.Y, -v1.Z);
            if (v1.X == 0)          // have to add in these statements because "-0" will be returned otherwise
                newV.X = 0;
            if (v1.Y == 0)
                newV.Y = 0;
            if (v1.Z == 0)
                newV.Z = 0;

            return newV;
        }
        
        //  multiply
        public static Vector operator *(Vector v1, double scalar)
        {
            return new Vector(v1.X * scalar, v1.Y * scalar, v1.Z * scalar);
        }

        // divide
        public static Vector operator /(Vector v1, double scalar)
        {
            return new Vector(v1.X / scalar, v1.Y / scalar, v1.Z / scalar);
        }

        //  new ToString
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
