using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    internal class Stats : GameAction
    {
        public override List<string> keyWords => new List<string>() { "stats" };

        public override List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords)
        {
            var result = new List<ConsoleOutput>();
            result.Add(new ConsoleOutput("Health: "));
            result.Add(controller.playerController.GetHealth());
            result.Add(new ConsoleOutput("Movement: "));
            result.Add(controller.playerController.GetMovement());
            result.Add(new ConsoleOutput("ActionPoints: "));
            result.Add(controller.playerController.GetActionPoints());
            return result;
        }
    }
}
