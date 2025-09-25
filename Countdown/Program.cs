// See https://aka.ms/new-console-template for more information

// Challenge: Countdown

void Countdown(int number)
{
    if (number <= 0) return ;
    Console.WriteLine(number);
    Countdown(number - 1);
}

Countdown(10);

