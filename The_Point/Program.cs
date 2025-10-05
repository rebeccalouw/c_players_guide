// See https://aka.ms/new-console-template for more information

// Boss Battle: The Point

Point one = new Point(2, 3);
Point two = new Point(-4, 0);

Console.WriteLine($"Point one: ({one.X}, {one.Y})");
Console.WriteLine($"Point two: ({two.X}, {two.Y})");

public class Point {
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
    public Point()
    {
        X = 0;
        Y = 0;
    }

}