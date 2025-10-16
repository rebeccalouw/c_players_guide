namespace Fountain;

public abstract class Monster
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; } = true;

    protected Monster(Location start) => Location = start;

    public abstract void Activate(FountainOfObjectsGame game);
}