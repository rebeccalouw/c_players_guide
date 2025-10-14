// See https://aka.ms/new-console-template for more information

// Challenge: The Robot Pilot

int healthPointsManticore = 10;
int healthPointsCity = 15;
int round = 1;
Random random = new Random();

int playerOneChoice = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore?", 0, 100);
Console.Clear();

do
{   
    int damagePoints = CalculateRoundDamagePoints(round);
    
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine($"STATUS: Round {round}   City: {healthPointsCity}/15   Manticore: {healthPointsManticore}/10");
    Console.WriteLine($"The cannon is expected to deal {damagePoints} damage this round.");

    int canonRange = random.Next(0, 101);
    Console.WriteLine($"Robot fires at range {canonRange}!");

    if (canonRange == playerOneChoice)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        healthPointsManticore-= damagePoints;
        
        if (healthPointsManticore > 0)
            healthPointsCity -= 1;
    }
    else if (canonRange > playerOneChoice)
    {
        Console.WriteLine("That round OVERSHOT the target.");
        healthPointsCity -= 1;
    }
    else
    {
        Console.WriteLine("That round FELL SHORT of the target.");
        healthPointsCity -= 1;
    }
    
    round ++;
}
while (healthPointsManticore > 0 && healthPointsCity > 0);

if (healthPointsManticore <= 0)
{
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
}
else if (healthPointsCity <= 0)
{
    Console.WriteLine("Oh no! The city of Consolas has been destroyed!");
}

int AskForNumberInRange(string text, int min, int max)
{
    int response;
    do
    {
        Console.Write($"{text} ({min}..{max}): ");
        response = Convert.ToInt32(Console.ReadLine());
    }
    while (response < min || response > max);

    return response;
}

int CalculateRoundDamagePoints(int roundNumber)
{
    if (round % 3 == 0 && roundNumber % 5 == 0) return 10;
    else if (round % 3 == 0 || roundNumber % 5 == 0) return 3;
    return 1;
};