using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameControllers.GameActions;

namespace TextBasedAdventure4.GameControllers
{
    public class UserInputController
    {
        private GameController gameController;

        public UserInputController(GameController gameController)
        {
            this.gameController = gameController;
        }

        public List<GameAction> gameActions = new List<GameAction>()
        {
            new Inspect(),
            new Move(),
        };

        public void TakeUserInputAndRespond()
        {
            string userInput = Util.ReadLine();
            userInput = userInput.ToLower();
            List<string> seperatedInputWords = new List<string>(userInput.Split(' '));
            string actionWord = seperatedInputWords.First();
            var gameAction = gameActions.Where(x => x.keyWords.Contains(actionWord)).Single();
            Util.Write(gameAction.RespondToInput(gameController, seperatedInputWords));
        }
    }
}
