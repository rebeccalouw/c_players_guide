// See https://aka.ms/new-console-template for more information

// Expansion: The Game Status

using System.Runtime.CompilerServices;
using Terminal.Gui;

Application.Init();

try
{
    Ui.CreateLogWindow();
    
    Application.MainLoop.Invoke(() =>
    {
        string playerName = AskName();

        Party heroes = new Party("Heroes");
        heroes.Add(new Character(playerName, new PunchAttack(), 25));

        Party monstersWave1 = new Party("Monsters (Wave 1)");
        monstersWave1.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));

        Party monstersWave2 = new Party("Monsters (Wave 2)");
        monstersWave2.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));
        monstersWave2.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));

        Party monstersWave3 = new Party("The Uncoded One");
        monstersWave3.Add(new Character("THE UNCODED ONE", new UnravelingAttack(), 15));

        int mode = AskMode();
    
        IPlayer heroesPlayer = (mode == 1 || mode == 3) ? new TuiHumanPlayer() : new ComputerPlayer();
        IPlayer monstersPlayer = (mode == 2) ? new ComputerPlayer() : new TuiHumanPlayer();
    
        List<Party> waves = new List<Party> { monstersWave1, monstersWave2, monstersWave3 };
    
        Ui.Log("The Battle Series begins!");
        Ui.Log();

        for (int i = 0; i < waves.Count; i++)
        {
            Party currentMonsters = waves[i];
            Ui.Log($"--- Battle {i + 1}: Heroes vs {currentMonsters.Name} ---");
            Ui.Log();
    
            Battle battle = new Battle(heroes,  currentMonsters, heroesPlayer, monstersPlayer);
            BattleOutcome outcome = battle.Run();

            if (outcome == BattleOutcome.MonstersWin)
            {
                Ui.Log();
                Ui.Log("Series over: The monsters have stopped the heroes.");
                break;
            }

            if (i < waves.Count - 1)
            {
                Ui.Log();
                Ui.Log("Heroes advance to the next battle!");
                Ui.Log();
            }
            else
            {
                Ui.Log();
                Ui.Log("All battles won! The Uncoded One is defeated.");
            }
        }
    });

    Application.Run();
}

finally
{
    Application.Shutdown();
}
static string AskName()
{
    string result = "TOG";

    Dialog dlg = new Dialog("True Programer", 40, 7);
    Label label = new Label(1, 1, "Enter name:");
    TextField input = new TextField("TOG")
    {
        X = 1,
        Y = Pos.Bottom(label) + 1,
        Width = Dim.Fill() - 2
    };

    var ok = new Button("OK");
    ok.IsDefault = true;
    ok.Clicked += () =>
    {
        string text = input.Text.ToString() ?? "";
        result = string.IsNullOrEmpty(text) ? "TOG" : text.Trim().ToUpperInvariant();
        Application.RequestStop();
    };

    dlg.Add(label, input);
    dlg.AddButton(ok);

    Application.Run(dlg);
    return  result;
}

static int AskMode()
{
    int idx = MessageBox.Query(
        "Game Mode",
        "Choose game mode:",
        "1 - Player vs Computer",
        "2 - Computer vs Computer",
        "3 - Human vs Human"
    );
    return idx + 1;
}

static class Ui
{
    private static TextView? _log;
    public static void CreateLogWindow()
    {
        var topBar = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("_File", new MenuBarItem[]
            {
                new MenuBarItem("_Quit", "", () => Application.RequestStop())
            })
        });
        Application.Top.Add (topBar);

        var win = new Window("Boss Battle")
        {
            X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill()
        };

        _log = new TextView
        {
            ReadOnly = true,
            WordWrap = true,
            X = 0, Y = 0,
            Width = Dim.Fill(), Height = Dim.Fill()
        };
        
        win.Add(_log);
        Application.Top.Add (win);
        Application.Refresh();
    }

    public static void Log(string text = "")
    {
        if (_log != null)
        {
            var existing = _log.Text.ToString() ?? string.Empty;
            _log.Text = existing + text + Environment.NewLine;
            _log.MoveEnd();
            Application.Refresh();
        }
        else
        {
            Console.WriteLine(text);
        }
    }
}

class TuiHumanPlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character actor)
    {
        int idx = MessageBox.Query(
        "Choose Action",
        $"{actor.Name}'s turn",
            $"1 - Standard Attack ({actor.StandardAttack.Name})",
                "2 - Do Nothing");

                int choice = idx + 1;

                if (choice == 1)
                {
                    Party enemy = battle.GetEnemyPartyFor(actor);
                    Character target = enemy.Members[0];
                    return new AttackAction(battle, actor, target, actor.StandardAttack);
                }

                return new DoNothingAction(actor);

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
        Ui.Log($"{_actor.Name} did NOTHING.");
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
        Ui.Log($"{_attacker.Name} used {_attack.Name} on {_target.Name}.");
        
        int damage = _attack.GetDamage();
        _target.TakeDamage(damage);
        
        Ui.Log($"{_attack.Name} dealt {damage} damage to {_target.Name}.");
        Ui.Log($"{_target.Name} is now at {_target.CurrentHp}/{_target.MaxHp}");

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
            ShowStatus(character);
            
            Ui.Log($"It is {character.Name}'s turn...");
            IAction action = controller.PickAction(this, character);
            action.Run();
            Ui.Log($"--------------------------------------------------");
            Thread.Sleep(500);
        }
    }

    private void ShowStatus(Character active)
    {
        Ui.Log(
            "============================================== BATTLE STATUS ==============================================");
        
        Ui.Log(_heroes.Name.ToUpper());
        foreach (Character hero in _heroes.Members)
        {
            string marker = ReferenceEquals(hero, active) ? ">>" : " ";
            string name = hero.Name.PadRight(12);
            string hp = $"({hero.CurrentHp}/{hero.MaxHp})";
            Ui.Log($"{marker} {name} {hp}");
        }
        
        Ui.Log("----------------------------------------- VS -----------------------------------------");

        
        Ui.Log(_monsters.Name.ToUpper());
        foreach (Character monster in _monsters.Members)
        {
            string marker = ReferenceEquals(monster, active) ? ">>" : " ";
            string name = monster.Name.PadRight(12);
            string hp = $"({monster.CurrentHp}/{monster.MaxHp})";
            Ui.Log($"{marker} {name} {hp}");
        }
        
        Ui.Log("=====================================================================================");
        Ui.Log(); 
    }

    public void RemoveCharacter(Character character)
    {
        Party party = GetPartyFor(character);
        party.Members.Remove(character);
        Ui.Log($"{character.Name} has been defeated!");

        if (party.Members.Count == 0)
        {
            _isOver = true;
            if (party == _monsters)
            {
                _outcome = BattleOutcome.HeroesWin;
                Ui.Log("Heroes have won! The Uncoded One was defeated.");
            }
            else
            {   
                _outcome = BattleOutcome.MonstersWin;
                Ui.Log("Monsters have won! The Uncoded One's forces have prevailed.");
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