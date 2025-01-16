
// Scientific Notation numbers RE = ^[+-]?(\d+(\.\d+)?)([eE][+-]?\d+)?$

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"^[+-]?(\d+(\.\d+)?)([eE][+-]?\d+)?$";
        string[] inputs = { "8e4", "5e-2", "6e9" };

        foreach (var input in inputs)
        {
            bool isMatch = Regex.IsMatch(input, pattern);
            Console.WriteLine($"Is '{input}' a valid scientific notation number? {isMatch}");
        }
    }
}
