using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    internal class Exit : GameAction
    {
        public override List<string> keyWords => new List<string>(){ "exit" };

        public override List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords)
        {
            throw new NotImplementedException();
        }
    }
}
