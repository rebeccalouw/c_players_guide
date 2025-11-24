// ATTACKS

abstract class Attack
{
    public string Name { get; }
    public double SuccessChance { get; }

    protected Attack(string name, double successChance)
    {
        Name = name.ToUpperInvariant();
        SuccessChance = successChance;
    }

    public abstract int GetDamage();
}

class PunchAttack : Attack
{
    public PunchAttack() : base("PUNCH", 1.0) { }

    public override int GetDamage()
    {
        return 1;
    }
}

class BoneCrunchAttack : Attack
{
    private static readonly Random random = new Random();
    
    public BoneCrunchAttack() : base("BONE CRUNCH", 1.0) { }

    public override int GetDamage()
    {
        return random.Next(2);
    }
}

class UnravelingAttack : Attack
{
    private static readonly Random random = new Random();
    public UnravelingAttack() : base("UNRAVELING", 1.0) { }

    public override int GetDamage()
    {
        return random.Next(3); 
    }
}

class QuickShotAttack : Attack
{
    public QuickShotAttack() : base("QUICK SHOT", 0.5) { }

    public override int GetDamage() => 3;
}
interface IAction
{
    void Run();
}