// See https://aka.ms/new-console-template for more information

// Challenge: Attacks

using System.Runtime.CompilerServices;

Console.Write("Enter the True Programmer's name: ");
string? input = Console.ReadLine();
string playerName = string.IsNullOrWhiteSpace(input) ? "TOG" : input.Trim().ToUpperInvariant();

Party heroes = new Party("Heroes");
Party monsters = new Party("Monsters");

heroes.Add(new Character(playerName, new Attack("PUNCH")));
monsters.Add(new Character("SKELETON", new Attack("BONE CRUNCH")));

IPlayer heroesPlayer = new ComputerPlayer();
IPlayer monstersPlayer = new ComputerPlayer();

Console.WriteLine("Battle starts!");

Battle battle = new Battle(heroes, monsters, heroesPlayer, monstersPlayer);
battle.Run();


class Attack
{
    public string Name { get; }

    public Attack(string name)
    {
        Name = name.ToUpperInvariant();
    }
}

interface IAction
{
    void Run();
}

class DoNothingAction : IAction
{
    private readonly Character _actor;

    public DoNothingAction(Character actor)
    {
        _actor = actor;
    }
    
    public void Run()
    {
        Console.WriteLine($"{_actor.Name} did NOTHING.");
    }
}

class AttackAction : IAction
{
    private readonly Character _attacker;
    private readonly Character _target;
    private readonly Attack _attack;

    public AttackAction(Character attacker, Character target, Attack attack)
    {
        _attacker = attacker;
        _target = target;
        _attack = attack;
    }

    public void Run()
    {
        Console.WriteLine($"{_attacker.Name} used {_attack.Name} on {_target.Name}.");
    }
}

interface IPlayer
{
    IAction PickAction(Battle battle, Character actor);
}

class ComputerPlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character actor)
    {
        Party enemy = battle.GetEnemyPartyFor(actor);
        Character target = enemy.Members[0];
        Thread.Sleep(250);
        return new AttackAction(actor, target, actor.StandardAttack);
    }
}

class Character
{
    public string Name { get; }
    public Attack StandardAttack { get; }

    public Character(string name, Attack standardAttack)
    {
        Name = name;
        StandardAttack = standardAttack;
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
            RunTurnOrder(_heroes, _heroesPlayer);
            RunTurnOrder(_monsters,  _monstersPlayer);
        }
    }

    private void RunTurnOrder(Party actingParty, IPlayer controller)
    {
        foreach (Character character in actingParty.Members)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");
            IAction action = controller.PickAction(this, character);
            action.Run();
            Console.WriteLine($"--------------------------");
            Thread.Sleep(500);
        }
    }

    public Party GetPartyFor(Character character)
    {
        if (_heroes.Members.Contains(character)) return _heroes;
        return _monsters;
    }
    
    public Party GetEnemyPartyFor(Character character)
    {
        if (_heroes.Members.Contains(character)) return _monsters;
        return _heroes;
    }
}