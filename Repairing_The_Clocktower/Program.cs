// See https://aka.ms/new-console-template for more information

// Challenge: Repairing the Clocktower

Console.Write("Please enter a number: ");
int input = Convert.ToInt32(Console.ReadLine());

if (input % 2 == 0) {
    Console.WriteLine("Tick");
}
else {
    Console.WriteLine("Tock");
};
