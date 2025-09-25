// See https://aka.ms/new-console-template for more information

// Challenge: The Defense of Consolas

Console.Title = "Defense of Consolas";
Console.BackgroundColor = ConsoleColor.DarkRed;

Console.Write("Target row: ");
int targetRow = Convert.ToInt32(Console.ReadLine());

Console.Write("Target column: ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Deploy to: \n ({targetRow}, {targetColumn - 1}) \n ({targetRow -1 }, {targetColumn}) \n ({targetRow}, {targetColumn + 1}) \n ({targetRow + 1}, {targetColumn})");

Console.ResetColor();
Console.Beep();