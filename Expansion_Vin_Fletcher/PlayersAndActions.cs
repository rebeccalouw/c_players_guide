using Terminal.Gui;


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


interface IPlayer
{
    IAction PickAction(Battle battle, Character actor);
}

class ComputerPlayer : IPlayer
{
    public IAction PickAction(Battle battle, Character actor)
    {
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
