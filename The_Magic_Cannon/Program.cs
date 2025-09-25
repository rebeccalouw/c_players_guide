// See https://aka.ms/new-console-template for more information

// Challenge: The Magic Cannon


for (int i = 1; i <= 100; i++)
{
    bool isFire = (i % 3 == 0);
    bool isElectric = (i % 5 == 0);

    if (isFire && isElectric)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Fire and electric blast!");
    }
    else if (isFire)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(i + " - Fire blast!");
    }
    else if (isElectric)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine(i + " - Electric blast!");
    }
    else
    {
        Console.ResetColor();
        Console.WriteLine(i + " - Normal");
    }
    
    Console.ResetColor();
}