// See https://aka.ms/new-console-template for more information

// Challenge: Converting Directions to Offsets

Direction directionEast = Direction.East;
Console.WriteLine($"{directionEast} - {(BlockOffset)directionEast}");

Direction directionNorth = Direction.North;
Console.WriteLine($"{directionNorth} - {(BlockOffset)directionNorth}");


public record BlockCoordinate(int Row, int Column);

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1,0),
            Direction.South => new BlockOffset(+1, 0),
            Direction.East => new BlockOffset(0, -1),
            Direction.West => new BlockOffset(0, +1)
        };
    }
}
public enum Direction { North, East, South, West };