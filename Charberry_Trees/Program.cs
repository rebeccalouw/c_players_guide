// See https://aka.ms/new-console-template for more information

// Challenge: Charberry Trees

CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);


while (true)
    tree.MaybeGrow();
public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action? Ripened;
    public void MaybeGrow()
    {
// Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }

    public void Harvest()
    {
        if (Ripe)
            Ripe = false;
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipened;
    }

    private void OnRipened() =>
        Console.WriteLine($"[{DateTime.Now:T}] A charberry tree has ripened!");
}

public class Harvester
{
    private int _harvestCount = 0;
    private readonly CharberryTree _tree;

    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnRipened;
    }

    private void OnRipened()
    {
        _harvestCount++;
        _tree.Harvest();
        Console.WriteLine($"Harvested! Total harvest: {_harvestCount}");
    }
}