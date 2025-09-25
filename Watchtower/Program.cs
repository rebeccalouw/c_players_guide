// See https://aka.ms/new-console-template for more information

// Challenge: Watchtower

Console.WriteLine("Oh no, an enemy was spotted, please help us to prepare defense!");

Console.WriteLine("Enter x coordinate value: ");
int x = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter y coordinate value: ");
int y = Convert.ToInt32(Console.ReadLine());


if (x < 0)
{
    if (y > 0)
    {
        Console.WriteLine("The enemy is to the Northwest!");
    }
    else if (y < 0)
    {
        Console.WriteLine("The enemy is to the Southwest!");
    }
    else
    {
        Console.WriteLine("The enemy is to the West!");
    }
}
else if (x > 0)
{
    if (y > 0)
    {
        Console.WriteLine("The enemy is to the Northeast!");
    }
    else if (y < 0)
    {
        Console.WriteLine("The enemy is to the Southeast!");
    }
    else
    {
        Console.WriteLine("The enemy is to the East!");
    }
}
else
{
    if (y > 0)
    {
        Console.WriteLine("The enemy is to the North!");
    }
    else if (y < 0)
    {
        Console.WriteLine("The enemy is to the South!");
    }
    else
    {
        Console.WriteLine("The enemy is here!");
    }
}