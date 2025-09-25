// See https://aka.ms/new-console-template for more information

// Challenge: The Dominion of the Kings

// Estate: 1 point
// Duchy: 3 points
// Province: 6 points

Console.Write("Enter the number of Estates you have: ");
int estates = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the number of Duchies you have: ");
int duchies = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the number of Provinces you have: ");
int provinces = Convert.ToInt32(Console.ReadLine());

int totalPoints = estates * 1 + duchies * 3 + provinces * 2;

Console.WriteLine("Total points are: " + totalPoints);