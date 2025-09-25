// See https://aka.ms/new-console-template for more information

// Challenge: The Prototype

int pilotInput = AskForNumberInRange("Please enter a number between 0 and 100: ", 0, 100);


Console.Clear();


int hunterInput = -1;

while (pilotInput != hunterInput)
{   
    Console.Write("Please enter a number between 0 and 100 to guess the enemy's spot: ");
    hunterInput = Convert.ToInt32(Console.ReadLine());
    
    if (hunterInput < pilotInput)
    {
        Console.WriteLine($"{hunterInput} is too low.");
    }
    else if (hunterInput > pilotInput)
    {
        Console.WriteLine($"{hunterInput} is too high.");
    }
}

Console.Write("You guessed the number!");

int AskForNumberInRange(string text, int min, int max)
{
    int response;
    do
    {
        Console.Write($"{text} ({min}..{max}): ");
        response = Convert.ToInt32(Console.ReadLine());
    }
    while (response < min || response > max);

    return response;
}