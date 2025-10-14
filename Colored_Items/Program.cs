// See https://aka.ms/new-console-template for more information

// Challenge: Colored Items

var blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
var redBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
var greenAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

blueSword.Display();
redBow.Display();
greenAxe.Display();
public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Colour { get; }

    public ColoredItem(T item, ConsoleColor colour)
    {
        Item = item;
        Colour = colour;
    }

    public void Display()
    {
        Console.ForegroundColor = Colour;
        Console.WriteLine(Item);
    }
}

public class Sword
{
    public override string ToString() => "Sword";
}

public class Bow
{
    public override string ToString() => "Bow";
}

public class Axe {
    public override string ToString() => "Axe";
}