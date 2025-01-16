
// Floating Point numbers RE = ^[+-]?([0-9]{1,5}(\.[0-9]{1,5})?|\.[0-9]{1,5})$

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"^[+-]?([0-9]{1,5}(\.[0-9]{1,5})?|\.[0-9]{1,5})$";
        string input = "42.42";

        bool isMatch = Regex.IsMatch(input, pattern);
        Console.WriteLine($"Is the input a valid floating point number? {isMatch}");
    }
}
