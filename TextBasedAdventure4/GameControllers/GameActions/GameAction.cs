using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    public abstract class GameAction
    {
        public abstract List<string> keyWords { get; }

        public abstract List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords);

    }
}
