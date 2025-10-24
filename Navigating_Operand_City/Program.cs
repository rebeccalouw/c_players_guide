// See https://aka.ms/new-console-template for more information

// Challenge: Navigating Operand City

Console.WriteLine(new BlockCoordinate(5, 2) + new BlockOffset(0, 1));
Console.WriteLine(new BlockCoordinate(2, 3) + Direction.South);

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate currCordinate, BlockOffset offset) => 
        new BlockCoordinate(currCordinate.Row + offset.RowOffset, currCordinate.Column + offset.ColumnOffset);

    public static BlockCoordinate operator +(BlockCoordinate currCoordinate, Direction direction)
    {
        return currCoordinate + (direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(+1, 0),
            Direction.West  => new BlockOffset(0, -1),
            Direction.East  => new BlockOffset(0, +1),
        });
    }
};
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West };