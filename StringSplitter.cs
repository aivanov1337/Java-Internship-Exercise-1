using System;
using System.Collections.Generic;
using System.Text;

namespace Java_Internship_Exercise
{
    public class StringSplitter
    {
        public class StringInformation
        {
            public char character { get; set; }
            public int position { get; set; }
        }

        public string alphabet;
        public List<StringInformation> uppercaseList = new List<StringInformation>();
        public List<StringInformation> lowercaseList = new List<StringInformation>();
        public List<int> takenPositions = new List<int>();

        public bool isValidExpression(string expression)
        {
            //If the expression contains letters outside of the defined alphabet, return false.
            if (!ContainsOnlyAlphabetLetters(expression))
            {
                return false;
            }

            /*Since every phrase starts with an uppercase letter and ends with a lowercase letter,
             * the number of uppercase letters must be equal to the number of lowercase letters.
             * If it isn't, the expression is invalid and we return false.
             */
            else if(CompareNumberOfStartersAndEnders(expression) == false)
            {
                return false;
            }

            /*
             * It is stated the phrases must start with an uppercase letter. The expression
             * consists of a number of phrases, which means that the expression must start
             * with an uppercase letter. If it doesn't, it's invalid and we return false.
             */
            else if(StartsWithUppercaseLetter(expression) == false)
            {
                return false;
            }

            /*
             * Phrases must end with a lowercase letter. This means that the expression itself
             * must end on a lowercase letter. If it doesn't, it's invalid and we return false.
             */
            else if(EndsWithLowercaseLetter(expression) == false){
                return false;
            }


            /* 
             * If the expression passes the validity checks above, we begin to test it
             * for more complex logic.
             * 
             * We get all of the Lowercase and Uppecase letters and we create a
             * "StringInformation" object for each of them, which stores their 
             * Character and their position within the string.
             */
            GetAllLowercaseLetters(expression);
            GetAllUppercaseLetters(expression);


            /*
             * After that, for each of the uppercase letters, we try and find
             * a corresponding lowercase letter to the right of them.
             * If all of them return true, then the expression is valid.
             */
            foreach(StringInformation s in uppercaseList)
            {
                FindLowercaseAfterIndex(s.position, s.character, expression);
            }

            return true;
        }



        public bool ContainsOnlyAlphabetLetters(string format)
        {
            foreach (char c in format)
            {
                if (!alphabet.Contains(c.ToString()))
                    return false;
            }
            return true;
        }

        public int GetNumberOfUppercaseLetters(string input)
        {
            int number = 0;
            char[] list = input.ToCharArray();

            foreach(char c in list)
            {
                if (Char.IsUpper(c))
                {
                    number++;
                }
            }
            return number;
        }

        public int GetNumberOfLowercaseLetters(string input)
        {
            char[] list = input.ToCharArray();
            int number = 0;

            foreach (char c in list)
            {
                if (Char.IsLower(c))
                {
                    number++;
                }
            }
            return number;
        }

        public bool CompareNumberOfStartersAndEnders(string input)
        {
            int uppercaseLetters = GetNumberOfUppercaseLetters(input);
            int lowercaseLetters = GetNumberOfLowercaseLetters(input);

            if (uppercaseLetters == lowercaseLetters)
            {
                return true;
            }
            else return false;
        }

        public bool StartsWithUppercaseLetter(string input)
        {
            char[] charArray = input.ToCharArray();
            char firstLetter = charArray[0];

            if (Char.IsUpper(firstLetter))
            {
                return true;
            }

            return false;
        }

        public bool EndsWithLowercaseLetter(string input)
        {
            char[] charArray = input.ToCharArray();
            char lastLetter = charArray[charArray.Length-1];

            if (Char.IsLower(lastLetter))
            {
                return true;
            }

            return false;
        }

        public void GetAllUppercaseLetters(string input)
        {
            char[] charList = input.ToCharArray();

            for(int i=0; i<charList.Length; i++)
            {
                if (Char.IsUpper(charList[i]))
                {
                    StringInformation strinf = new StringInformation() { character = charList[i], position = i };
                    uppercaseList.Add(strinf);
                }
            }
        }

        public void GetAllLowercaseLetters(string input)
        {
            char[] charList = input.ToCharArray();

            for (int i = 0; i < charList.Length; i++)
            {
                if (Char.IsLower(charList[i]))
                {
                    StringInformation strinf = new StringInformation() { character = charList[i], position = i };
                    lowercaseList.Add(strinf);
                }
            }
        }

        public bool FindLowercaseAfterIndex(int index,char character, string input)
        {
            char[] charList = input.ToCharArray();

            for(int i=index; i<charList.Length; i++)
            {

                if (Char.IsLower(charList[i]))
                {
                    if (Char.ToLower(character) == charList[i] && !takenPositions.Contains(i))
                    {
                        takenPositions.Add(i);

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
