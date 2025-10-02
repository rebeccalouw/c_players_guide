// See https://aka.ms/new-console-template for more information

// Challenge: Vin's Trouble

Arrow chosenArrow = GetArrow();
Console.WriteLine($"The chosen arrow costs {chosenArrow.GetTotalCost()} gold.");

Arrow GetArrow()
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
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _length;
    public Arrow(Arrowhead arrowheadType, Fletching fletchingType, float shaftLength)
    {
        _arrowhead = arrowheadType;
        _fletching = fletchingType;
        _length = shaftLength;
    }
    
    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;    

    public float GetTotalCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5
        };

        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };
        
        float shaftCost = _length * 0.05f;
        
        return arrowheadCost + fletchingCost + shaftCost;
    }
    
}


enum Arrowhead { Steel = 1, Wood = 2, Obsidian = 3 };
enum Fletching { Plastic = 1, TurkeyFeathers = 2, GooseFeathers = 3 };