
// Words start with 't,m' RE = \b[tTmM]\w*

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "My name is Haseeb Ahmed";
        string pattern = @"\b[tTmM]\w*";

        MatchCollection matches = Regex.Matches(text, pattern);
        
        Console.WriteLine("Words starting with 't' or 'm':");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
