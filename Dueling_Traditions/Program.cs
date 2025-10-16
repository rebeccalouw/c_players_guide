// See https://aka.ms/new-console-template for more information

// Challenge: Dueling Traditions
namespace Fountain;

class Program
{
    static void Main()
    {
        FountainOfObjectsGame game = CreateSmallGame();
        game.Run();
    }
    
    static FountainOfObjectsGame CreateSmallGame()
    {
        Map map = new Map(4, 4);
        Location start = new Location(0, 0);
        map.SetRoomTypeAtLocation(start, RoomType.Entrance);
        map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Fountain);

        Monster[] monsters = new Monster[] { };

        return new FountainOfObjectsGame(map, new Player(start), monsters);
    }
}