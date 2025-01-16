
// RE for relational operators: ==|!=|>=|<=|>|<

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "if (a >= b && c != d || e == f)";
        string pattern = @"==|!=|>=|<=|>|<";
        
        MatchCollection matches = Regex.Matches(input, pattern);
        
        Console.WriteLine("Relational operators found:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
