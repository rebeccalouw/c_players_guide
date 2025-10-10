// See https://aka.ms/new-console-template for more information

// Challenge: Room Coordinates

Coordinate a = new Coordinate(3,3);
Coordinate b = new Coordinate(2, 3);
Coordinate c = new Coordinate(2, 2);

Console.WriteLine($"Is coordinate a adjacent to coordinate b? {Coordinate.AreAdjacent(a,b)}" );
Console.WriteLine($"Is coordinate b adjacent to coordinate c? {Coordinate.AreAdjacent(b,c)}" );
Console.WriteLine($"Is coordinate a adjacent to coordinate c? {Coordinate.AreAdjacent(a,c)}" );

public readonly struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = a.Row - b.Row;
        int columnChange = a.Column - b.Column;

        if (Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
        if (Math.Abs(columnChange) <= 1 && columnChange == 0) return true;

        return false;
    }
    
}