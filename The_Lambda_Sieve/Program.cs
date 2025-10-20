// See https://aka.ms/new-console-template for more information

// Challenge: The Lambda Sieve

Sieve sieve = PickFilter();

while (true)
{
    Console.Write("Enter a number: ");
    int input = Convert.ToInt32(Console.ReadLine());
    
    string veredict = sieve.IsGood(input) ? "good" : "bad";
    Console.WriteLine($"The number is {veredict}.");
}
Sieve PickFilter()
{
    Console.WriteLine("Which filter would you like to use? 1 - Even, 2 - Positive, 3 - Multiple of ten: ");
    string? choiceText = Console.ReadLine();
    int.TryParse(choiceText, out int choice);

    Func<int, bool> rule = choice switch
    {
        1 => n => n % 2 == 0,
        2 => n => n > 0,
        3 => n => n % 10 == 0,
        _ => n => n % 2 == 0
    };
    
    Console.WriteLine($"Using filter {(choice == 2 ? "Positive" : choice == 3 ? "Multiple of ten" : "Even")}.");
    return new Sieve(rule);
}

public class Sieve
{
    private readonly Func<int, bool> _decide;

    public Sieve(Func<int, bool> decisionFunction)
    {
        _decide = decisionFunction;
    }
    
    public bool IsGood(int number) => _decide(number);
}