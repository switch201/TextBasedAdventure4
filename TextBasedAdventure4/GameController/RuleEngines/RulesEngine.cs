using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameController.RuleEngines;
using TextBasedAdventure4.GameObjects;

namespace TextBasedAdventure4.GameController
{
    internal class RulesEngine
    {
        public static RuleResult CanChangeRooms(Actor gameObject, Room targetRoom, Room startingRoom)
        {
            bool success = targetRoom.IsAdjacent(startingRoom);
            var result = new RuleResult()
            {
                Success = success
            };
            if (!success)
            {
                result.Messages.Add($"{gameObject.GetName()}, is not adjacent to the {targetRoom.GetName()}");
            }
            return result;
        }
    }
}
