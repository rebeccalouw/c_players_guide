// See https://aka.ms/new-console-template for more information

// Challenge: Better Random

Random random = new Random();

Console.WriteLine(random.NextDouble(15));
Console.WriteLine(random.NextDouble(7));
Console.WriteLine(random.NextString("up", "down", "left", "right"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.3));

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max)
    {
        return random.NextDouble() * max;
    }

    public static string NextString(this Random random, params string[] choices)
    {   
        if (choices == null || choices.Length == 0)
            Console.WriteLine("Please enter options");
        
        int index = random.Next(choices.Length);
        return choices[index];
    }

    public static bool CoinFlip(this Random random, double chanceOfHeads = 0.5)
    {
        if (chanceOfHeads < 0) chanceOfHeads = 0;
        if (chanceOfHeads > 1) chanceOfHeads = 1;
        
        return random.NextDouble() < chanceOfHeads;
    }
}
