using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameControllers.RuleEngines
{
    public static class MoveRules
    {
        public static RuleResult ValidateCoordinates(List<List<Space>> board, (int, int) space)
        {
            var result = new RuleResult() { Success = true };
           if(!IsSpaceOnBoard(board, space))
            {
                result.Success = false;
                result.Messages.Add(new ConsoleOutput("That space is not on the board\n"));
            }
            return result;
        }

        public static RuleResult HasMovement(Actor actor)
        {
            var result = new RuleResult() { Success = actor.CurrentMovement > 0 };
            if (!result.Success)
            {
                result.Messages.Add(new ConsoleOutput($"{actor.Name} does not have enough movement points.\n"));
            }
            return result;
        }

        private static bool IsSpaceOnBoard(List<List<Space>> board, (int, int) space)
        {
            if (space.Item1 < 0 || space.Item2 < 0)
            {
                return false;
            }
            if (board.Count() <= space.Item1)
            {
                return false;
            }
            if (board.ElementAt(space.Item1).Count() <= space.Item2)
            {
                return false;
            }
            return true;
        }
    }
}
