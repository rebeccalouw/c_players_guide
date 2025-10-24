// See https://aka.ms/new-console-template for more information

// Challenge: Indexing Operand City

BlockCoordinate coordinate = new BlockCoordinate(2, 5);

Console.WriteLine(coordinate[0]);
Console.WriteLine(coordinate[1]);


public record BlockCoordinate(int Row, int Column)
{   
    public int this[int index] => index switch { 0 => Row, 1 => Column };
    
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


