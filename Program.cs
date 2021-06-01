using System;
using System.Collections.Generic;

namespace Java_Internship_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            StringSplitter stringSplitter = new StringSplitter() { alphabet = "aAbBcC" };
            List<string> testInputs = new List<string>() { "AaBb", "BCAacb", "BCcAab", "ACABbBbaca" , "AabB" , "BCAcaB", "hfdmlen", "ACBcAabCca" };

            Console.WriteLine("The alphabet is " + stringSplitter.alphabet);

            foreach(string s in testInputs)
            {
                if (stringSplitter.isValidExpression(s))
                {
                    Console.WriteLine("V  " +s + " is a valid expression.");
                }
                else
                {
                    Console.WriteLine("X  " + s + " is an invalid expression.");
                }
            }
            Console.ReadLine();
        }
    }
}
