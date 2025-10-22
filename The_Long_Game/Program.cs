// See https://aka.ms/new-console-template for more information

// Challenge: The Long Game

int score = 0;

Console.WriteLine("Welcome to this game! Please enter your username: ");
string username = Console.ReadLine();

if (File.Exists($"{username}.txt"))
{
    string previousScore = File.ReadAllText($"{username}.txt");
    score = int.Parse(previousScore);   
    Console.WriteLine($"Hi there {username}, welcome back, your score will resume at {score}");
    Console.WriteLine("Let's see how many keys you can press! If you wish to quit, please press the escape key.");
}

while (true)
{
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.Escape)
        break;

    score++;
    Console.WriteLine($"Your current score is {score}.");
}

File.WriteAllText($"{username}.txt", score.ToString());

