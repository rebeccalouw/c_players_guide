using Terminal.Gui;


class TuiHumanPlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character actor)
    {
        Party party = battle.GetPartyFor(actor);
        bool hasPotion = party.HealthPotions > 0;

        int idx;

        if (hasPotion)
        {
            idx = MessageBox.Query(
                "Choose Action",
                $"{actor.Name}'s turn",
                $"1 - Standard Attack ({actor.StandardAttack.Name})",
                "2 - Do Nothing",
                "3 - Use Health Potion"
                );
        }
        else
        {
            idx = MessageBox.Query(
                "Choose Action",
                $"{actor.Name}'s turn",
                $"1 - Standard Attack ({actor.StandardAttack.Name})",
                "2 - Do Nothing"
            );
        }
        
        int choice = idx + 1;

        if (choice == 1)
        {
            Party enemy = battle.GetEnemyPartyFor(actor);
            Character target = enemy.Members[0];
            return new AttackAction(battle, actor, target, actor.StandardAttack);
        }

        if (choice == 2)
        {
            return new DoNothingAction(actor);
        }

        if (hasPotion && choice == 3)
        {
            return new UseHealthPotionAction(battle, actor);
        }
        
        return new DoNothingAction(actor);
    }
}


interface IPlayer
{
    IAction PickAction(Battle battle, Character actor);
}

class ComputerPlayer : IPlayer
{
    private static readonly Random random = new Random();
    public IAction PickAction(Battle battle, Character actor)
    {
        Party party = battle.GetPartyFor(actor);
        
        bool hasPotion = party.HealthPotions > 0;
        bool lowHealth = actor.CurrentHp < (actor.MaxHp / 2);

        if (hasPotion && lowHealth)
        {
            if (random.NextDouble() < 0.25)
            {
                return new UseHealthPotionAction(battle, actor);
            }
        }
        
        Party enemy = battle.GetEnemyPartyFor(actor);
        if (enemy.Members.Count == 0)
        {
            return new DoNothingAction(actor);
        }
        Character target = enemy.Members[0];
        Thread.Sleep(250);
        return new AttackAction(battle, actor, target, actor.StandardAttack);
    }
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
    private static readonly Random random = new Random();

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

        bool hit;
        if (_attack.SuccessChance <= 0.0)
        {
            hit = false;
        }
        else if (_attack.SuccessChance >= 1.0)
        {
            hit = true;
        }
        else
        {
            hit = random.NextDouble() < _attack.SuccessChance;
        }

        if (!hit)
        {
            Ui.Log($"{_attacker.Name}'s {_attack.Name} MISSED!");
            return;
        }
        
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

class UseHealthPotionAction : IAction
{
    private readonly Battle _battle;
    private readonly Character _actor;

    public UseHealthPotionAction(Battle battle, Character actor)
    {
        _battle = battle;
        _actor = actor;
    }

    public void Run()
    {
        Party party = _battle.GetPartyFor(_actor);

        if (!party.UseOneHealthPotion())
        {
            Ui.Log($"{_actor.Name} tried to use a potion, but there were none left!");
            return;
        }
        
        int before = _actor.CurrentHp;
        
        _actor.Heal(10);
        
        int healedAmount = _actor.CurrentHp - before;
        
        Ui.Log($"{_actor.Name} used a HEALTH POTION and recovered {healedAmount} HP.");
        Ui.Log($"{_actor.Name} is now at {_actor.CurrentHp}/{_actor.MaxHp}.");
        Ui.Log($"{party.Name} now has {party.HealthPotions} potion(s) left.");
    }
}