using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    internal class Move : GameAction
    {
        private static List<string> direction = new List<string>()
        {
            "up",
            "down",
            "left",
            "right"
        };
        public override List<string> keyWords => new List<string>() { "move" };

        public override List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords)
        {
            List<ConsoleOutput> output = new List<ConsoleOutput>();
            if (!direction.Contains(seperatedWords.Last()))
            {
                output.Add(new ConsoleOutput("you have to say a direction"));
            }
            else
            {
                var start = controller.roomController.GetPlayerSpace();
                var end = (0,0);
                switch (seperatedWords.Last())
                {
                    case "up":
                        end = (start.Item1 - 1, start.Item2);
                        break;
                    case "down":
                        end = (start.Item1 + 1, start.Item2);
                        break;
                    case "left":
                        end = (start.Item1, start.Item2 - 1);
                        break;
                    case "right":
                        end = (start.Item1, start.Item2 + 1);
                        break;
                }
                controller.roomController.ChangeSpace(start, end);
                output.Add(new ConsoleOutput("You moved!"));
            }
            output.Add(new ConsoleOutput("\n"));
            return output;
            // The above just makes sure the input is valid there is something special about that as well.
            //TODO this is a special thing here I think it needs to be moved to a rules engine
        }
    }
}
