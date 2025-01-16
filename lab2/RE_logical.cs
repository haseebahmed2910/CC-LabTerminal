
// RE for logical operators: &&|\|\||!

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "if (a && b || !c)";
        string pattern = @"&&|\|\||!";
        
        MatchCollection matches = Regex.Matches(input, pattern);
        
        Console.WriteLine("Logical operators found:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
