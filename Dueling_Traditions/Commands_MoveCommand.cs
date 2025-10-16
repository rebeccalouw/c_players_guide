namespace Fountain;

public class MoveCommand : ICommand
{
    public Direction Direction { get; }

    public MoveCommand(Direction direction) => Direction = direction;

    public void Execute(FountainOfObjectsGame game)
    {
        Location currentLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.West  => new Location(currentLocation.Row, currentLocation.Column - 1),
            Direction.East  => new Location(currentLocation.Row, currentLocation.Column + 1),
            _ => currentLocation
        };

        if (game.Map.IsOnMap(newLocation))
            game.Player.Location = newLocation;
        else
            ConsoleHelper.WriteLine("There is a wall there.", ConsoleColor.Red);
    }
}