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
            if(seperatedWords.Count == 1)
            {
                output.Add(new ConsoleOutput("What do you want to inspect? You can inspect the room, your hand, your deck, or the discard pile.\n" +
                    "You can also inspect specific cards and enemies.\n"));
            }
            else
            {
                if (directObject == "room")
                {
                    output.Add(new ConsoleOutput("You take a quick look around the room.\n"));
                    output.AddRange(controller.roomController.GetRoomLayout());
                    var npcs = controller.roomController.npcController.ListNPCs();
                    if (npcs.Count > 0)
                    {
                        output.Add(new ConsoleOutput($"In the room with you, you see the following:\n"));
                        output.AddRange(npcs);
                    }
                    else
                    {
                        output.Add(new ConsoleOutput("Looks like there is no one in here\n"));
                    }

                }
                if (deckNames.Contains(directObject))
                {
                    output.AddRange(controller.playerDeckController.GetPlayerCardNames());
                }
                if (directObject == "hand")
                {
                    output.AddRange(controller.playerDeckController.GetPlayerHand());
                }
                if (directObject == "discard")
                {
                    output.AddRange(controller.playerDeckController.GetDiscardPile());
                }
                if (output.Count() == 0)
                {
                    output.AddRange(controller.playerDeckController.GetCardInfo(string.Join(" ", seperatedWords.Skip(1))));
                }
            }
            return output;
        }
    }
}
