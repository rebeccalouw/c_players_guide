namespace Fountain;

public class FountainSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game) =>
        game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain;

    public void DisplaySense(FountainOfObjectsGame game)
    {
        if (game.IsFountainOn)
            ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.DarkCyan);
        else
            ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.DarkCyan);
    }
}