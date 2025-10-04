// See https://aka.ms/new-console-template for more information

// Challenge: Arrow Factories

Console.WriteLine("What kind of arrow would you like?");
Console.WriteLine("1 - Elite Arrow");
Console.WriteLine("2 - Beginner Arrow");
Console.WriteLine("3 - Marksman Arrow");
Console.WriteLine("4 - Custom Arrow");

int answer = Convert.ToInt32(Console.ReadLine());

Arrow arrow = answer switch
{
    1 => Arrow.CreateEliteArrow(),
    2 => Arrow.CreateBeginnerArrow(),
    3 => Arrow.CreateMarksmanArrow(),
    _ => CreateCustomArrow(),
};
    
Console.WriteLine($"The chosen arrow costs {arrow.GetTotalCost} gold.");

Arrow CreateCustomArrow()
{
    Arrowhead chosenArrowhead = GetArrowheadType();
    Fletching chosenFletching = GetFletchingType();
    float length = GetShaftLength();

    return new Arrow(chosenArrowhead, chosenFletching, length);
}

Arrowhead GetArrowheadType()
{
    Console.WriteLine("Enter the arrowhead type:");
    Console.WriteLine("1 - steel\n2 - wood\n3 - obsidian");
    int type = Convert.ToInt32(Console.ReadLine());

    return (Arrowhead)type;
}

Fletching GetFletchingType()
{
    Console.WriteLine("Enter the fletching type:");
    Console.WriteLine("1 - plastic\n2 - turkey feather\n3 - goose feather");
    int type = Convert.ToInt32(Console.ReadLine());

    return (Fletching)type;
}

float GetShaftLength()
{
    float length = 0;

    do
    {
        Console.Write("Enter length for arrow shaft (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }
    while (length < 60 || length > 100);
    
    return length;
}



class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get;  }
    public float Length { get; }
    public Arrow(Arrowhead arrowheadType, Fletching fletchingType, float shaftLength)
    {
        Arrowhead = arrowheadType;
        Fletching = fletchingType;
        Length = shaftLength;
    }

    public float GetTotalCost
    {   
        get
        {
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5
            };

            float fletchingCost = Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };
        
            float shaftCost = Length * 0.05f;
        
            return arrowheadCost + fletchingCost + shaftCost;  
        }
    }
    
    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow( )=> new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 65);
}

enum Arrowhead { Steel = 1, Wood = 2, Obsidian = 3 };
enum Fletching { Plastic = 1, TurkeyFeathers = 2, GooseFeathers = 3 };