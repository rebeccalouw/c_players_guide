
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
            if (_isOver)
                break;

            Party enemy = GetEnemyPartyFor(character);
            if (enemy.Members.Count == 0)
                break;
            
            ShowStatus(character);
            
            Ui.Log($"It is {character.Name}'s turn...");
            IAction action = controller.PickAction(this, character);
            action.Run();
            Ui.Log($"----------------------------------------------------------------------------");
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
        
        Ui.Log("--------------------------------------- VS ---------------------------------------");

        
        Ui.Log(_monsters.Name.ToUpper());
        foreach (Character monster in _monsters.Members)
        {
            string marker = ReferenceEquals(monster, active) ? ">>" : " ";
            string name = monster.Name.PadRight(12);
            string hp = $"({monster.CurrentHp}/{monster.MaxHp})";
            Ui.Log($"{marker} {name} {hp}");
        }
        
        Ui.Log("===========================================================================================================");
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