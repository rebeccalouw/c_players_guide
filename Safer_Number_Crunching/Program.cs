// See https://aka.ms/new-console-template for more information

// Challenge: Safer Number Crunching

int number;
double decimalNumber;
bool trueFalse;


do
{
    Console.WriteLine("Hey there, please enter a whole number, no decimals, please. ");
} while(!int.TryParse(Console.ReadLine(), out number));
Console.WriteLine(number);


do
{
    Console.WriteLine("Please enter a number: ");
} while (!double.TryParse(Console.ReadLine(), out decimalNumber));


do
{
    Console.WriteLine("Please enter true or false: ");
} while (!bool.TryParse(Console.ReadLine(), out trueFalse));

