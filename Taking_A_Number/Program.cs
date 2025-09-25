// See https://aka.ms/new-console-template for more information

// Challenge: Taking a Number


// Added this method to Buying_Inventory Challenge

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int response = Convert.ToInt32(Console.ReadLine());
    return response;
}


// Added this method to The_Prototype Challenge 

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