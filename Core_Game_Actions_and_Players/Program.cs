// See https://aka.ms/new-console-template for more information

// Challenge: Actions and Players

Console.Write("Enter the True Programmer's name: ");
string? input = Console.ReadLine();
string playerName = string.IsNullOrWhiteSpace(input) ? "TOG" : input.Trim().ToUpperInvariant();

Party heroes = new Party("Heroes");
Party monsters = new Party("Monsters");

heroes.Add(new Character(playerName));
monsters.Add(new Character("SKELETON"));

IPlayer heroesPlayer = new ComputerPlayer();
IPlayer monstersPlayer = new ComputerPlayer();

Console.WriteLine("Battle starts!");

Battle battle = new Battle(heroes, monsters, heroesPlayer, monstersPlayer);
battle.Run();


interface IAction
{
    void Run(Character actor);
}

class DoNothingAction : IAction
{
    public void Run(Character actor)
    {
        Console.WriteLine($"{actor.Name} did NOTHING.");
    }
}

interface IPlayer
{
    IAction PickAction(Character actor, Party ownParty, Party enemyParty);
}

class ComputerPlayer : IPlayer
{
    public IAction PickAction(Character actor, Party ownParty, Party enemyParty)
    {
        Thread.Sleep(250);
        return new DoNothingAction();
    }
}

class Character
{
    public string Name { get; }

    public Character(string name)
    {
        Name = name;
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
    private readonly IPlayer _heroesPlayer;
    private readonly IPlayer _monstersPlayer;

    public Battle(Party heroes, Party monsters, IPlayer heroesPlayer, IPlayer monstersPlayer)
    {
        _heroes = heroes;
        _monsters = monsters;
        _heroesPlayer = heroesPlayer;
        _monstersPlayer = monstersPlayer;
    }

    public void Run()
    {
        while (true)
        {
            RunTurnOrder(_heroes, _monsters, _heroesPlayer);
            RunTurnOrder(_monsters, _heroes, _monstersPlayer);
        }
    }

    private static void RunTurnOrder(Party actingParty, Party opposingParty, IPlayer controller)
    {
        foreach (Character character in actingParty.Members)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");
            IAction action = controller.PickAction(character, actingParty, opposingParty);
            action.Run(character);
            Console.WriteLine($"--------------------------");
            Thread.Sleep(500);
        }
    }
}