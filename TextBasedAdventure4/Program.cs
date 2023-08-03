using TextBasedAdventure4;
using TextBasedAdventure4.GameController;
using TextBasedAdventure4.Games.Factories;
using TextBasedAdventure4.Games;

var game = GameObjectFactory.CreateGame("TestGame");

game.Start();
var gameController = new GameController(game);

string userinput = Util.ReadLine();



while(userinput != "exit")
{
    if(userinput == "go test")
    {
        var result = gameController.AttemptoChangeRooms(new ActionRequest<Actor, Room, Room>
        {
            Subject=game.player,
            DirectObject=game.Rooms.Last(),
            IndirectObject=game.GetObjectsRoom(game.player),
            FollowRules = true
        });
    }
    else
    {
        Util.WriteLine("type 'go test'");
    }
    userinput = Util.ReadLine();
}