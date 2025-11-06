// See https://aka.ms/new-console-template for more information

// Challenge: The True Programmer

Console.Write("Enter the True Programmer's name: ");
string? input = Console.ReadLine();
string playerName = string.IsNullOrWhiteSpace(input) ? "TOG" : input.Trim().ToUpperInvariant();

Party heroes = new Party("Heroes");
Party monsters = new Party("Monsters");

heroes.Add(new Character(playerName));
monsters.Add(new Character("SKELETON"));

Console.WriteLine("Battle starts!");

Battle battle = new Battle(heroes, monsters);
battle.Run();

class Character
{
    public string Name { get; }

    public Character(string name)
    {
        Name = name;
    }

    public void TakeTurn()
    {
        Console.WriteLine($"{Name} did NOTHING.");
    }
}

class Party
{
    public string Name { get; }
    public List<Character> Members { get; } = new List<Character>();

    public Party(string name)
    {
        Name = name;
    }

    public void Add(Character character)
    {
        Members.Add(character);
    }
}

class Battle
{
    private readonly Party _heroes;
    private readonly Party _monsters;

    public Battle(Party heroes, Party monsters)
    {
        _heroes = heroes;
        _monsters = monsters;
    }

    public void Run()
    {
        while (true)
        {
            RunTurnOrder(_heroes);
            RunTurnOrder(_monsters);
        }
    }

    private static void RunTurnOrder(Party party)
    {
        foreach (Character character in party.Members)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");
            character.TakeTurn();
            Console.WriteLine($"--------------------------");
            Thread.Sleep(500);
        }
    }
}