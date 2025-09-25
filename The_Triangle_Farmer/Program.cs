// See https://aka.ms/new-console-template for more information

// Challenge: The Triangle Farmer

Console.Write("Enter the triangle's base: ");
double baseLength = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the triangle's height: ");
double height = Convert.ToDouble(Console.ReadLine());

double triangleArea = (baseLength * height) / 2.0;

Console.WriteLine("The triangle area is: " + triangleArea);
