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
            new Exit(),
        };

        private List<string> NormalizeInput(string userInput)
        {
            userInput = userInput.ToLower();
            return new List<string>(userInput.Split(' '));
        }

        private GameAction GetAction(List<string> input)
        {
            string actionWord = input.First();
            return gameActions.Where(x => x.keyWords.Contains(actionWord)).SingleOrDefault();
        }

        public void TakeUserInputAndRespond()
        {
            var seperatedWords = NormalizeInput(Util.ReadLine());
            var gameAction = GetAction(seperatedWords);
            if(gameAction != null)
            {
                Util.Write(gameAction.RespondToInput(gameController, seperatedWords));
            }
        }
    }
}
