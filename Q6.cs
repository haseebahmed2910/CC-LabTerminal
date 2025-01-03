using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //  Part 1
        
        Console.WriteLine("Enter usernames (separated by commas):");
        string input = Console.ReadLine();
        string[] usernames = input.Split(',').Select(u => u.Trim()).ToArray();

        List<string> validUsernames = new List<string>();
        List<string> invalidUsernames = new List<string>();
        Dictionary<string, string> generatedPasswords = new Dictionary<string, string>();

        foreach (var username in usernames)
        {
            if (ValidateUsername(username, out string validationMessage))
            {
                validUsernames.Add(username);
                DisplayUsernameDetails(username);
                string password = GeneratePassword();
                string strength = EvaluatePasswordStrength(password);
                Console.WriteLine($"Generated Password: {password} (Strength: {strength})\n");
                generatedPasswords[username] = password;
            }
            else
            {
                Console.WriteLine($"{username} - Invalid ({validationMessage})\n");
                invalidUsernames.Add(username);
            }
        }

        SaveResultsToFile(usernames.Length, validUsernames.Count, invalidUsernames.Count, validUsernames, generatedPasswords);

        if (invalidUsernames.Count > 0)
        {
            Console.WriteLine("Invalid Usernames: " + string.Join(", ", invalidUsernames));
            Console.WriteLine("Do you want to retry invalid usernames? (y/n):");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                Console.WriteLine("Enter invalid usernames:");
                string retryInput = Console.ReadLine();
                usernames = retryInput.Split(',').Select(u => u.Trim()).ToArray();
                foreach (var username in usernames)
                {
                    if (ValidateUsername(username, out string validationMessage))
                    {
                        validUsernames.Add(username);
                        DisplayUsernameDetails(username);
                        string password = GeneratePassword();
                        string strength = EvaluatePasswordStrength(password);
                        Console.WriteLine($"Generated Password: {password} (Strength: {strength})\n");
                        generatedPasswords[username] = password;
                    }
                    else
                    {
                        Console.WriteLine($"{username} - Invalid ({validationMessage})\n");
                    }
                }
                SaveResultsToFile(usernames.Length, validUsernames.Count, invalidUsernames.Count, validUsernames, generatedPasswords);
            }
        }
    }

    static bool ValidateUsername(string username, out string message)
    {
        if (!Regex.IsMatch(username, "^[a-zA-Z]") )
        {
            message = "Username must start with a letter.";
            return false;
        }
        if (!Regex.IsMatch(username, "^[a-zA-Z0-9_]{5,15}$"))
        {
            message = "Username length must be between 5 and 15, and can only contain letters, numbers, and underscores.";
            return false;
        }
        message = string.Empty;
        return true;
    }

    static void DisplayUsernameDetails(string username)
    {
        int uppercaseCount = username.Count(char.IsUpper);
        int lowercaseCount = username.Count(char.IsLower);
        int digitCount = username.Count(char.IsDigit);
        int underscoreCount = username.Count(c => c == '_');

        Console.WriteLine($"{username} - Valid\n   Letters: {uppercaseCount + lowercaseCount} (Uppercase: {uppercaseCount}, Lowercase: {lowercaseCount}), Digits: {digitCount}, Underscores: {underscoreCount}\n");
    }

    //  Part 2
    
    static string GeneratePassword()
    {
        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string specialChars = "!@#$%^&*";
        const string allChars = upperChars + lowerChars + digits + specialChars;

        Random random = new Random();
        var password = new StringBuilder();

        password.Append(GetRandomChars(upperChars, 2, random));
        password.Append(GetRandomChars(lowerChars, 2, random));
        password.Append(GetRandomChars(digits, 2, random));
        password.Append(GetRandomChars(specialChars, 2, random));

        int remaining = 12 - password.Length;
        password.Append(GetRandomChars(allChars, remaining, random));

        return new string(password.ToString().OrderBy(_ => random.Next()).ToArray());
    }

    static string GetRandomChars(string charSet, int count, Random random)
    {
        return new string(Enumerable.Repeat(charSet, count).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    //  Part 3  (Part 3 is also in the Part 1 and 2)
    
    static string EvaluatePasswordStrength(string password)
    {
        if (password.Length >= 12 &&
            Regex.IsMatch(password, "[A-Z]") &&
            Regex.IsMatch(password, "[a-z]") &&
            Regex.IsMatch(password, "\\d") &&
            Regex.IsMatch(password, "[!@#$%^&*]"))
        {
            return "Strong";
        }
        return "Medium";
    }

    static void SaveResultsToFile(int total, int valid, int invalid, List<string> validUsernames, Dictionary<string, string> passwords)
    {
        using (StreamWriter writer = new StreamWriter("UserDetails.txt"))
        {
            writer.WriteLine("Validation Results:");
            foreach (var username in validUsernames)
            {
                string password = passwords[username];
                string strength = EvaluatePasswordStrength(password);
                writer.WriteLine($"{username} - Valid\nGenerated Password: {password} (Strength: {strength})\n");
            }

            writer.WriteLine("Summary:");
            writer.WriteLine($"- Total Usernames: {total}");
            writer.WriteLine($"- Valid Usernames: {valid}");
            writer.WriteLine($"- Invalid Usernames: {invalid}");
        }
    }
}
