//  Date: 10-23-19
//  Chapter 36 pg 228 - 229
//  Purpose: Create Extension Methods
using System;
using System.IO;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // word count
            string message = "";
            Console.WriteLine($"The statement \n\t{message} \ncontains {message.WordCount()} words and characters");
            Console.WriteLine();
            message = "How many words are here?";
            Console.WriteLine($"The statement \n\t{message} \ncontains {message.WordCount()} words and characters");
            Console.WriteLine();

            // sentence count
            message = "";
            Console.WriteLine($"The statement\n\t {message} \ncontains {message.SentenceCount()} sentences");
            Console.WriteLine();
            message = "How many sentences are here-I guess I'll have to count to find out-Let's go";
            Console.WriteLine($"The statement\n\t {message} \ncontains {message.SentenceCount()} sentences");
            Console.WriteLine();
            message = "How many sentences are here? I guess I'll have to count to find out. Let's go!";
            Console.WriteLine($"The statement\n\t {message} \ncontains {message.SentenceCount()} sentences");
            Console.WriteLine();

            // paragraph count
            message = "";
            Console.WriteLine($"The statement\n\t {message} \ncontains {message.ParagraphCount()} paragraphs");
            Console.WriteLine();
            message = "How many paragraphs are here? \nI guess I'll have to count to find out. \nLet's go!";
            Console.WriteLine($"The statement\n\t {message} \ncontains {message.ParagraphCount()} paragraphs");
            Console.WriteLine();

            // line count
            string[] fileContentsByLine = File.ReadAllLines(@"C:\Users\Apprenti3\Documents\Visual Studio 2019\Projects\DieRolling\DieRolling\Program.cs");
            Console.WriteLine($"The file read in (without blank lines) contains {fileContentsByLine.LineCount()} lines");
            Console.WriteLine();          
        }
    }

    public static class ExtensionMethods
    {
        // returns the count of words in the given input string
        public static int WordCount(this string text)
        {
            char[] separators = new char[] { ' ', '\n', '\r', '\t' };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // returns the count of sentences in the given input string
        public static int SentenceCount(this string text)
        {
            char[] separators = new char[] { '.', '!', '?' };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // returns the count of paragraphs in the given input string
        public static int ParagraphCount(this string text)
        {
            char[] separators = new char[] { '\n' };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // returns the line count in the given input file (without blank lines)
        public static int LineCount(this string[] text)
        {
            int count = 0;
            foreach (string s in text)
            {
                if (s.Length == 0)
                {
                    count++;        // counting blank lines in file
                }
            }
            return text.Length - count;
        }
    }




}
