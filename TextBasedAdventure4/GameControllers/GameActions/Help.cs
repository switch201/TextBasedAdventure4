using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    internal class Help : GameAction
    {
        public override List<string> keyWords => new List<string>() { "help" };

        public override List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords)
        {
            var result = new List<ConsoleOutput>();
            result.Add(new ConsoleOutput("This is a turn based game where you fight enemeis!\n" +
                "You can check your stats by typing 'stats'\n" +
                "\tYour main stats are Health, Movement points, and Action Points\n" +
                "\tYou spend action points to play cards\n" +
                "\tYou spend movement points to move\n" +
                "\tHealth is self explanitory\n" +
                "You can move by typing 'move' followed by 'up', 'down', 'left', or 'right'\n" +
                "You can inspect the room, your hand, your deck, or the discard by typing\n" +
                "'inspect' followed by the thing you want to inspect.\n" +
                "\tYou can also inspect specific cards and enemies by name to see what they are all about.\n" +
                "You can play a card from your hand by typing 'play' followed by the card name." +
                "\tIf required by the card you have to also type a direction after." +
                "You can type 'exit' to exit the game\n"));
            return result;
        }
    }
}
