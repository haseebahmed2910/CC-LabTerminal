using System;

namespace DFA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a variable name:");
            string input = Console.ReadLine();

            if (IsValidVariableName(input))
            {
                Console.WriteLine("The variable name is valid.");
            }
            else
            {
                Console.WriteLine("The variable name is invalid.");
            }
        }

        static bool IsValidVariableName(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            // State 0: Initial state
            int state = 0;

            foreach (char c in input)
            {
                switch (state)
                {
                    case 0:
                        if (char.IsLetter(c) || c == '_')
                        {
                            state = 1; // Move to state 1 if the first character is a letter or underscore
                        }
                        else
                        {
                            return false; // Invalid character for the initial state
                        }
                        break;

                    case 1:
                        if (char.IsLetterOrDigit(c) || c == '_')
                        {
                            state = 1; // Stay in state 1 if the character is a letter, digit, or underscore
                        }
                        else
                        {
                            return false; // Invalid character for state 1
                        }
                        break;

                    default:
                        return false; // Invalid state
                }
            }

            // Accepting state is state 1
            return state == 1;
        }
    }
}