using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameControllers.RuleEngines;
using TextBasedAdventure4.GameObjects;

namespace TextBasedAdventure4.GameControllers
{

    public enum GameState
    {
        Running,
        Exit
    }
    public class GameController
    {
        private Game currentGame;

        public RoomController roomController;

        public DeckController deckController;

        public UserInputController userInterface;

        public GameState gameState;

        public GameController(Game game) {
            currentGame = game;
            roomController = new RoomController(currentGame);
            deckController = new DeckController(currentGame);
            userInterface = new UserInputController(this);
        }

        public void StartBattle()
        {
            deckController.StartBattle();
        }

        public void StartTurn()
        {
            deckController.StartTurn();
        }
    }
}
