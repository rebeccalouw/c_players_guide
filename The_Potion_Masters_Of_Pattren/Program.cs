// See https://aka.ms/new-console-template for more information

// Challenge: The Potion Masters of Pattren

Potion currentPotion = Potion.Water;

while (true)
{
    Console.WriteLine("\n--------------------");
    Console.WriteLine($"Current potion is: {currentPotion}");
    Console.WriteLine("Choose enter the corresponding number of the ingredient that you would like to add:");
    Console.WriteLine("1 - Stardust \n2- Snake Venom \n3 - Dragon Breath \n4 - Shadow Glass \n5 - Eyeshine Gem");
    
    
    Ingredients ingredient = Convert.ToInt32(Console.ReadLine()) switch
    {
        1 => Ingredients.Stardust,
        2 => Ingredients.SnakeVenom,
        3 => Ingredients.DragonBreath,
        4 => Ingredients.ShadowGlass,
        5 => Ingredients.EyeshineGem,
        _ => Ingredients.Water
    };

    currentPotion = (currentPotion, ingredient) switch
    {   
        (Potion.Water,        Ingredients.Water)        => Potion.Water,
        (Potion.Water,        Ingredients.Stardust)     => Potion.Elixir,
        (Potion.Elixir,       Ingredients.SnakeVenom)   => Potion.Poison,
        (Potion.Elixir,       Ingredients.DragonBreath) => Potion.Flying,
        (Potion.Elixir,       Ingredients.ShadowGlass)  => Potion.Invisibility,
        (Potion.Elixir,       Ingredients.EyeshineGem)  => Potion.NightSight,
        (Potion.NightSight,   Ingredients.ShadowGlass)  => Potion.CloudyBrew,
        (Potion.Invisibility, Ingredients.EyeshineGem)  => Potion.CloudyBrew,
        (Potion.CloudyBrew,   Ingredients.ShadowGlass)  => Potion.Wraith,
        _ => Potion.Ruined
    };
    
    Console.WriteLine($"The potion becomes: {currentPotion}");

    if (currentPotion == Potion.Ruined)
    {
        Console.WriteLine("Oh no! The potion was ruined. Starting over with Water...");
        currentPotion = Potion.Water;
        continue;
    }
    
    Console.Write("Finish this potion? (y/n): ");
    string answer = Console.ReadLine();
    if (answer == "y" || answer == "Y" || answer == "Yes")
    {
        Console.WriteLine($"Final potion: {currentPotion}. Goodbye, until next time!");
        break;
    }
}

public enum Potion { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined };
public enum Ingredients { Water, Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem };