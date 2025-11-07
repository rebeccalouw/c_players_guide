// See https://aka.ms/new-console-template for more information

// Challenge: Death

using System.Runtime.CompilerServices;

Console.Write("Enter the True Programmer's name: ");
string? input = Console.ReadLine();
string playerName = string.IsNullOrWhiteSpace(input) ? "TOG" : input.Trim().ToUpperInvariant();

Party heroes = new Party("Heroes");
Party monsters = new Party("Monsters");

heroes.Add(new Character(playerName, new PunchAttack(), 25));
monsters.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));

IPlayer heroesPlayer = new ComputerPlayer();
IPlayer monstersPlayer = new ComputerPlayer();

Console.WriteLine("Battle starts!\n");

Battle battle = new Battle(heroes, monsters, heroesPlayer, monstersPlayer);
battle.Run();


abstract class Attack
{
    public string Name { get; }

    public Attack(string name)
    {
        Name = name.ToUpperInvariant();
    }

    public abstract int GetDamage();
}

class PunchAttack : Attack
{
    public PunchAttack() : base("PUNCH") { }

    public override int GetDamage()
    {
        return 1;
    }
}

class BoneCrunchAttack : Attack
{
    private static readonly Random random = new Random();
    
    public BoneCrunchAttack() : base("BONE CRUNCH") { }

    public override int GetDamage()
    {
        return random.Next(2);
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
    private readonly Battle _battle;
    private readonly Character _attacker;
    private readonly Character _target;
    private readonly Attack _attack;

    public AttackAction(Battle battle, Character attacker, Character target, Attack attack)
    {
        _battle = battle;
        _attacker = attacker;
        _target = target;
        _attack = attack;
    }

    public void Run()
    {
        Console.WriteLine($"{_attacker.Name} used {_attack.Name} on {_target.Name}.");
        
        int damage = _attack.GetDamage();
        _target.TakeDamage(damage);
        
        Console.WriteLine($"{_attack.Name} dealt {damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.CurrentHp}/{_target.MaxHp}");

        if (_target.CurrentHp == 0)
        {
            _battle.RemoveCharacter(_target);
        }
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
        return new AttackAction(battle, actor, target, actor.StandardAttack);
    }
}

class Character
{
    public string Name { get; }
    public Attack StandardAttack { get; }
    public int MaxHp { get; }
    public int CurrentHp { get; private set; }

    public Character(string name, Attack standardAttack, int maxHp)
    {
        Name = name;
        StandardAttack = standardAttack;
        MaxHp = maxHp;
        CurrentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0) amount = 0;
        int newHp = CurrentHp - amount;
        CurrentHp = newHp < 0 ? 0 : newHp;
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
    private bool _isOver;

    public Battle(Party heroes, Party monsters, IPlayer heroesPlayer, IPlayer monstersPlayer)
    {
        _heroes = heroes;
        _monsters = monsters;
        _heroesPlayer = heroesPlayer;
        _monstersPlayer = monstersPlayer;
        _isOver = false;
    }

    public void Run()
    {
        while (!_isOver)
        {
            RunTurnOrder(_heroes, _heroesPlayer);
            if (_isOver) break;
            RunTurnOrder(_monsters,  _monstersPlayer);
        }
    }

    private void RunTurnOrder(Party actingParty, IPlayer controller)
    {   
        List<Character> snapshot = new List<Character>(actingParty.Members);
        
        foreach (Character character in snapshot)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");
            IAction action = controller.PickAction(this, character);
            action.Run();
            Console.WriteLine($"--------------------------");
            Thread.Sleep(500);
        }
    }

    public void RemoveCharacter(Character character)
    {
        Party party = GetPartyFor(character);
        party.Members.Remove(character);
        Console.WriteLine($"{character.Name} has been defeated!");

        if (party.Members.Count == 0)
        {
            _isOver = true;
            if (party == _monsters)
            {
                Console.WriteLine("Heroes have won! The Uncoded One was defeated.");
            }
            else
            {
                Console.WriteLine("Monsters have won! The Uncoded One's forces have prevailed.");
            }
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