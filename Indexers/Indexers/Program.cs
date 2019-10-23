//  Date: 10-23-19
//  Chapter 33 pg 225
//  Purpose: Create a dictionary class that uses an indexer

using System;
using System.Collections.Generic;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dict = new Dictionary();
            dict["pear"] = "A fruit that comes in many colors";
            dict["apple"] = "A fruit that is best cold and with caramel";
            dict["banana"] = "A fruit that is usually yellow, avoid green ones";
            Console.WriteLine(dict["pear"]);
            Console.WriteLine(dict["apple"]);
            Console.WriteLine(dict["banana"]);
            dict["banana"] = "A fruit that grows in bunches";
            Console.WriteLine(dict["banana"]);
        }
    }

    class Dictionary
    {
        private static List<string> fruits = new List<string>();
        private static List<string> definitions = new List<string>();

        public string this[string inFruit]
        {
            get
            {
                return $"{inFruit}: " + definitions[fruits.IndexOf(inFruit)];
            }

            set 
            {
                int index = fruits.IndexOf(inFruit);
                if (index < 0)
                {
                    fruits.Add(inFruit);
                    definitions.Add(value);
                }
                else
                {
                    definitions[index] = value;
                }
            }
        }
    }
}
