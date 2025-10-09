// See https://aka.ms/new-console-template for more information


// Challenge: Packing Inventory

Pack pack = new Pack(5, 7, 12);

while (true)
{
    Console.WriteLine($"Your pack currently contains {pack.CurrentNoItems}/{pack.MaxItems} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");
    
    Console.WriteLine("What would you like to add?");
    Console.WriteLine("1 - Arrow \n2 - Bow \n3 - Rope \n4 - Water \n5 - Food \n6 - Sword");
    int response = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItemToAdd = response switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        6 => new Sword()
    };

    if (!pack.CanAdd(newItemToAdd))
    {
        Console.WriteLine("Sorry, could not add this item to the pack.");
    }
}

public class Pack
{
    public int MaxItems { get; }
    public float MaxVolume { get; }
    public float MaxWeight { get; }
    
    private InventoryItem[] _items;
    
    public int CurrentNoItems { get; private set; }
    public float CurrentVolume { get; private set; }
    public float CurrentWeight { get; private set; }

    public Pack(int maxItems, float maxVolume, float maxWeight)
    {
        MaxItems = maxItems;
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;

        _items = new InventoryItem[MaxItems];
    }

    public bool CanAdd(InventoryItem item)
    {
        if (CurrentNoItems >= MaxItems) return false;
        if (CurrentVolume + item.Volume > MaxVolume) return false;
        if (CurrentWeight + item.Weight > MaxWeight) return false;

        _items[CurrentNoItems] = item;
        CurrentNoItems++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }

    public override string ToString()
    {
        string packContents = "Pack containing ";
        if (CurrentNoItems == 0) packContents += "no items";

        for (int itemNo = 0; itemNo < CurrentNoItems; itemNo++)
        {
            packContents += _items[itemNo].ToString() + " ";
        }
        return packContents;
    }
}

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString() => "Arrow";
}

public class Bow : InventoryItem
{
    public Bow() : base (1,4) { }
    public override string ToString() => "Bow";
}

public class Rope : InventoryItem
{
    public Rope() : base (1,1.5f) { }
    public override string ToString() => "Rope";
}

public class Water : InventoryItem
{
    public Water() : base (2,3) { }
    public override string ToString() => "Water";
}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5f) { }
    public override string ToString() => "Food";
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
    public override string ToString() => "Sword";
}