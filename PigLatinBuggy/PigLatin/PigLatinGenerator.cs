using System;

namespace PigLatin
{
    class PigLatinGenerator
    {
        // user string is updated based on user input
        //pig latin output is auto updated through a listener
        public string[] UserString { get; set; }
        public string PigLatinOutput => ToPigLatin();

        public int FirstVowelIndex = -1;

        public PigLatinGenerator()
        {

        }

        //for testing made an overloaded constructor where I could pass in a string:
        public PigLatinGenerator(string input)
        {
            UserString = input.ToLower().Trim().Split(" ");
        }

        //sets string above
        public void SetString(string prompt)
        {
            Console.WriteLine(prompt);
            UserString = Console.ReadLine().ToLower().Trim().Split(" ");       
        }

        //returns true if c is a vowel, false if not.
        //fixed this bug as it was not returning true ever.
        private bool IsVowel(char w)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in vowels)
            {
                if (c == w)
                {
                    return true;
                }
            }
            return false;
        }

        //checking for special characters
        private bool HasSpecialChar(string substring)
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            foreach (char c in specialChars)
            {
                foreach (char w in substring)
                {
                    if (w == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //checking for vowels
        //fixed the logic here so it will return true if there is a vowel.
        private bool HasVowels(string substring)
        {
            foreach (char letter in substring)
            {
                if (IsVowel(letter))
                {
                    FirstVowelIndex = substring.IndexOf(letter);
                    return true;
                }
            }

            return false;
        }

        //cleaned this up and added calls to additional helper methods
        //so that this method was easier to follow. 
        //
        public string ToPigLatin()
        {
            string output = "";
            foreach (string sub in UserString)
            {
                //check for special chars
                if (HasSpecialChar(sub))
                {
                    output += sub + " ";
                    continue;
                }

                //now checking for vowels
                if (!HasVowels(sub))
                {
                    //if no vowels, return string as is
                    output += sub + " ";
                    continue;
                }

                //this logic is incorrect, it only finds first letter
                //but needs to find everything before first vowel.
                //char firstLetter = UserString[0];
                if (FirstVowelIndex == 0)
                {
                    //fixed this to return "way" at end instead of just ay.
                    output += sub + "way" + " ";
                }
                else
                {
                    //took out vowel index because i already accounted for it above.
                    string firstPart = sub.Substring(0, FirstVowelIndex);
                    string secondPart = sub.Substring(FirstVowelIndex);

                    output+= secondPart + firstPart + "ay" + " ";
                }
            }
            return output.Trim();
      
        }
    }
}
