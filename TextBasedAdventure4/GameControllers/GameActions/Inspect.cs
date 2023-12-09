using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    internal class Inspect : GameAction
    {
        private static List<string> deckNames = new List<string>() { "deck", "cards" };
        public override List<string> keyWords => new List<string>() { "view", "inspect" };
        public override List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords)
        {
            var output = new List<ConsoleOutput>() { };
            var directObject = seperatedWords.Last();
            if(directObject == "room")
            {
                output.AddRange(controller.roomController.GetRoomLayout());
            }
            if (deckNames.Contains(directObject))
            {
                return controller.deckController.GetPlayerCardNames();
            }
            if(directObject == "hand")
            {
                return controller.deckController.GetPlayerHand();
            }
            return output;
        }
    }
}
