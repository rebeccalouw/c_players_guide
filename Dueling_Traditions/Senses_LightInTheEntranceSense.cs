namespace Fountain;

public class LightInEntranceSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game) =>
        game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance;

    public void DisplaySense(FountainOfObjectsGame game) =>
        ConsoleHelper.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.", ConsoleColor.Yellow);
}