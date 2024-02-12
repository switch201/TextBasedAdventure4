using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameControllers.RuleEngines;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Decks;

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

        public DeckController playerDeckController;

        public UserInputController userInterface;

        public PlayerController playerController;

        public GameState gameState;

        public Dictionary<string, DeckController> npcDeckControllers = new Dictionary<string, DeckController>();

        public GameController(Game game) {
            currentGame = game;
            roomController = new RoomController(currentGame);
            playerDeckController = new DeckController(currentGame.player);
            userInterface = new UserInputController(this);
            playerController = new PlayerController(currentGame.player);
            InitializeNpcDecks(game);
        }

        private void InitializeNpcDecks(Game game)
        {
            // Doing this just for starting room now
            game.StartingRoom.GetNpcObjects().ForEach(x =>
            {
                npcDeckControllers.Add(x.Name, new DeckController(x));
            });
        }
        public void StartBattle()
        {
            // player shuffles and draws cards
            playerDeckController.StartBattle();

            // NPCs deck controllers inizilized

        }

        public void StartTurn()
        {
            playerDeckController.StartTurn();
        }

        public void PlayCard(string cardName, (int, int) targetSpace)
        {
            TriggerCardEffects(cardName, targetSpace);
            playerDeckController.PlayCardIntoDiscard(cardName);
        }

        private void TriggerCardEffects(string cardName, (int, int) targetSpace)
        {
            
            var effects = playerDeckController.GetCardEffects(cardName);
            roomController.AttackSpace(effects.Damage, targetSpace);
            roomController.AddActorToSpace(effects.Summonable, targetSpace);
        }
    }
}
