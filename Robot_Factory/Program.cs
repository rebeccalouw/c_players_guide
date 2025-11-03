// See https://aka.ms/new-console-template for more information

// Challenge: Robot Factory

using System.Dynamic;

int nextId = 1;
Console.WriteLine("Robot Factory\n");

while (true)
{
    dynamic robot = new ExpandoObject();
    robot.ID = nextId++;

    if (AskYesNo("Do you want to name this robot? (yes/no)"))
    {
        Console.WriteLine($"What is the robot's name?");
        string? name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) robot.Name = name.Trim();
    }

    if (AskYesNo("Do you want this robot to have a specific size? (yes/no) "))
    {
        Console.WriteLine($"What is its height? ");
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine($"What is its width? ");
        int width = int.Parse(Console.ReadLine());
        
        robot.Height = height;
        robot.Width = width;
    }

    if (AskYesNo("Does this robot need to be a specific colour? (yes/no) "))
    {
        Console.WriteLine($"What is its colour? ");
        string? colour = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(colour)) robot.Colour = colour.Trim();
    }
    
    Console.WriteLine();
    foreach (KeyValuePair<string, object> prop in (IDictionary<string, object>)robot) 
        Console.WriteLine($"{prop.Key}: {prop.Value}");
    Console.WriteLine();

    if (!AskYesNo("Do you want to build another robot? (y/n)"))
        break;
    
    Console.WriteLine();
}

static bool AskYesNo(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? s = Console.ReadLine();
        if (s is null) return false;
        s = s.Trim().ToLowerInvariant();
        if (s == "y" || s == "yes") return true;
        if (s == "n" || s == "no") return false;
        Console.WriteLine("Please answer 'yes' or 'no'.");
    }
}
