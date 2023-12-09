using TextBasedAdventure4;
using TextBasedAdventure4.GameControllers;
using TextBasedAdventure4.GameObjects.Factories;
using TextBasedAdventure4.GameObjects;

var game = GameObjectFactory.CreateGame("TestGame");

var gameController = new GameController(game);

var grid = gameController.roomController.GetRoomLayout();
Util.Write(grid);
gameController.StartBattle();
gameController.StartTurn();
while (gameController.gameState != GameState.Exit)
{
    gameController.userInterface.TakeUserInputAndRespond();
}
