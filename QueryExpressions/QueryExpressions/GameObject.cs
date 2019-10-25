using System;
using System.Collections.Generic;
using System.Text;

namespace QueryExpressions
{
    public class GameObject
    {
        // properties
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double MaxHP { get; set; }       // HP - Health Points
        public double CurrentHP { get; set; }
        public int PlayerID { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Location: ({X}, {Y}), Health Points: {CurrentHP}, Player: {PlayerID})";         
        }
    }
}