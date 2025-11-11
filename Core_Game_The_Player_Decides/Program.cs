// See https://aka.ms/new-console-template for more information

// Challenge: The Player Decides

using System.Runtime.CompilerServices;

Console.Write("Enter the True Programmer's name: ");
string? input = Console.ReadLine();
string playerName = string.IsNullOrWhiteSpace(input) ? "TOG" : input.Trim().ToUpperInvariant();

Party heroes = new Party("Heroes");
heroes.Add(new Character(playerName, new PunchAttack(), 25));

Party monstersWave1 = new Party("Monsters (Wave 1)");
monstersWave1.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));

Party monstersWave2 = new Party("Monsters (Wave 2)");
monstersWave2.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));
monstersWave2.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));

Party monstersWave3 = new Party("The Uncoded One");
monstersWave3.Add(new Character("THE UNCODED ONE", new UnravelingAttack(),15));


Console.WriteLine();
Console.WriteLine("Choose game mode: ");
Console.WriteLine("1 - Player (Heroes) vs Computer (Monsters)");
Console.WriteLine("2 - Computer vs Computer");
Console.WriteLine("3 - Human vs Human (you pick for both sides)");
int mode = int.Parse(Console.ReadLine()!);
IPlayer heroesPlayer;
IPlayer monstersPlayer;

if (mode == 1)
{
    heroesPlayer = new HumanPlayer();
    monstersPlayer = new ComputerPlayer();
}
else if (mode == 2)
{
    heroesPlayer = new ComputerPlayer();
    monstersPlayer = new ComputerPlayer();
}
else
{
    heroesPlayer = new HumanPlayer();
    monstersPlayer = new HumanPlayer();
}

List<Party> waves = new List<Party> { monstersWave1, monstersWave2, monstersWave3 };

Console.WriteLine("The Battle Series begins!\n");

for (int i = 0; i < waves.Count; i++)
{
    Party currentMonsters = waves[i];
    Console.WriteLine($"--- Battle {i + 1}: Heroes vs {currentMonsters.Name} ---\n");
    
    Battle battle = new Battle(heroes,  currentMonsters, heroesPlayer, monstersPlayer);
    BattleOutcome outcome = battle.Run();

    if (outcome == BattleOutcome.MonstersWin)
    {
        Console.WriteLine("\nSeries over: The monsters have stopped the heroes.");
        return;
    }

    if (i < waves.Count - 1)
    {
        Console.WriteLine("\nHeroes advance to the next battle!\n");
    }
    else
    {
        Console.WriteLine("\nAll battles won! The Uncoded One is defeated.");
    }
}

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

class UnravelingAttack : Attack
{
    private static readonly Random random = new Random();
    public UnravelingAttack() : base("UNRAVELING") { }

    public override int GetDamage()
    {
        return random.Next(3); 
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

class HumanPlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character actor)
    {
        Console.WriteLine($"It is {actor.Name}'s turn...");
        Console.WriteLine($"1 - Standard Attack ({actor.StandardAttack.Name})");
        Console.WriteLine("2 - Do Nothing");
        int choice = int.Parse(Console.ReadLine()!);

        if (choice == 1)
        {
            Party enemy = battle.GetEnemyPartyFor(actor);
            Character target = enemy.Members[0];
            return new AttackAction(battle, actor, target, actor.StandardAttack);
        }

        return new DoNothingAction(actor);
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
    private BattleOutcome _outcome;

    public Battle(Party heroes, Party monsters, IPlayer heroesPlayer, IPlayer monstersPlayer)
    {
        _heroes = heroes;
        _monsters = monsters;
        _heroesPlayer = heroesPlayer;
        _monstersPlayer = monstersPlayer;
        _isOver = false;
    }

    public BattleOutcome Run()
    {
        while (!_isOver)
        {
            RunTurnOrder(_heroes, _heroesPlayer);
            if (_isOver) break;
            RunTurnOrder(_monsters,  _monstersPlayer);
        }
        return _outcome;
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
                _outcome = BattleOutcome.HeroesWin;
                Console.WriteLine("Heroes have won! The Uncoded One was defeated.");
            }
            else
            {   
                _outcome = BattleOutcome.MonstersWin;
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

enum BattleOutcome { HeroesWin, MonstersWin }