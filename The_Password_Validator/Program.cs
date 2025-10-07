// See https://aka.ms/new-console-template for more information

// Boss Battle: The Password Validator

PasswordValidator validator = new PasswordValidator();

while (true)
{
    Console.WriteLine("Enter a password. Rules: 6–13 chars, at least 1 uppercase character, 1 lowercase character, 1 number, and may not contain 'T' or '&'.");
    string? password = Console.ReadLine();

    if (password == null)
    {
        Console.WriteLine("You are not allowed to save an empty password.");
        break;
    }
    
    if (validator.IsValid(password)) Console.WriteLine("You have successfully entered a valid password.");
    else Console.WriteLine("You entered an invalid password.");
}


public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (password.Length < 6) return false;
        if (password.Length > 13) return false;
        if (!HasUppercase(password)) return false;
        if (!HasLowercase(password)) return false;
        if (!HasNumber(password)) return false;
        if(Contains(password, 'T')) return false;
        if(Contains(password, '&')) return false;
        return true;
    }

    private bool HasUppercase(string password)
    {   
        foreach (char character in password)
            if (char.IsUpper(character)) return true;
        return false;
    }
    private bool HasLowercase(string password)
    {
        foreach (char character in password)
            if(char.IsLower(character)) return true;
        return false;
    }

    private bool HasNumber(string password)
    {
        foreach (char character in password)
            if(char.IsDigit(character)) return true;
        return false;
    }

    private bool Contains(string password, char character)
    {   
        foreach (char letter in password)
            if (letter == character) return true;
        return false;
    }
}