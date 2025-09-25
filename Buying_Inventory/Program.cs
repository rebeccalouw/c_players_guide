// See https://aka.ms/new-console-template for more information

// Challenge: Buying Inventory and Discounted Inventory

Console.WriteLine("The following items are available:");
Console.WriteLine("1 – Rope");
Console.WriteLine("2 – Torches");
Console.WriteLine("3 – Climbing Equipment");
Console.WriteLine("4 – Clean Water");
Console.WriteLine("5 – Machete");
Console.WriteLine("6 – Canoe");
Console.WriteLine("7 – Food Supplies");

int choice = AskForNumber("What number do you want to see the price of? ");


Console.Write("What is your name? ");
string name = Console.ReadLine();

string item = "";
decimal price = 0m; 

switch (choice)
{
    case 1: item = "Rope";              price = 10m;  break;
    case 2: item = "Torches";           price = 15m;  break;
    case 3: item = "Climbing Equipment";price = 25m;  break;
    case 4: item = "Clean Water";       price = 1m;   break;
    case 5: item = "Machete";           price = 20m;  break;
    case 6: item = "Canoe";             price = 200m; break;
    case 7: item = "Food Supplies";     price = 1m;   break;
    default:
        Console.WriteLine("We do not have this option in stock.");
        return;
}

if (name == "Rebecca")
{
    price = price / 2;
}

Console.WriteLine($"The price of {item} is: {price} gold");

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int response = Convert.ToInt32(Console.ReadLine());
    return response;
}