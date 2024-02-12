using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    internal class PlayCard : GameAction
    {
        private static List<string> direction = new List<string>()
        {
            "up",
            "down",
            "left",
            "right"
        };
        public override List<string> keyWords => new List<string>() { "play", "use"};

        public override List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords)
        {
            // Checks to see if the request makes any sense
            List<ConsoleOutput> output = new List<ConsoleOutput>();
            var cardName = seperatedWords[1];
            if (!direction.Contains(seperatedWords.Last()))
            {
                output.Add(new ConsoleOutput("you have to say a direction\n"));
            }
            else
            {
                var start = controller.roomController.GetPlayerSpace();
                var end = (0, 0);
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
                var ruleResult = controller.playerDeckController.CanPlayCard(cardName);
                if (ruleResult.Success)
                {
                    controller.PlayCard(cardName, end);
                    output.Add(new ConsoleOutput($"You Played {cardName}!\n"));
                }
                else
                {
                    output.AddRange(ruleResult.Messages);
                }
            }
            return output;
        }
    }
}
