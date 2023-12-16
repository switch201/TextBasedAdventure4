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
                output.AddRange(controller.deckController.GetPlayerCardNames());
            }
            if(directObject == "hand")
            {
                output.AddRange(controller.deckController.GetPlayerHand());
            }
            if(directObject == "discard")
            {
                output.AddRange(controller.deckController.GetDiscardPile());
            }
            if(output.Count() == 0)
            {
                output.AddRange(controller.deckController.GetCardInfo(string.Join(" ", seperatedWords.Skip(1))));
            }
            return output;
        }
    }
}
