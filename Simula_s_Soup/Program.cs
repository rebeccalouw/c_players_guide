// See https://aka.ms/new-console-template for more information

// Challenge: Simula’s Soup

(FoodType, MainIngredient, Seasoning) GetSoupCombination()
{
    Console.WriteLine("Enter the type of soup you want to make:");
    Console.WriteLine("1 - soup\n2 - stew\n3 - gumbo");
    int type = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter the main ingredient for your soup:");
    Console.WriteLine("1 - mushrooms\n2 - chicken\n3 - carrots\n4 - potatoes");
    int ingredient  = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter the type of seasoning would you like to use:");
    Console.WriteLine("1 - spicy\n2 - salty\n3 - sweet");
    int seasoning = Convert.ToInt32(Console.ReadLine());
    
    return ((FoodType)type, (MainIngredient)ingredient, (Seasoning)seasoning);
}

var soup = GetSoupCombination();
Console.WriteLine($"{soup.Item3} {soup.Item2} {soup.Item1}");


enum FoodType {Soup = 1, Stew = 2, Gumbo = 3};
enum MainIngredient {Mushrooms = 1, Chicken = 2, Carrots = 3, Potatoes = 4};
enum Seasoning {Spicy = 1, Salty = 2, Sweet = 3};