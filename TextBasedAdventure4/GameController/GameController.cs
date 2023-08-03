using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameController.RuleEngines;
using TextBasedAdventure4.Games;

namespace TextBasedAdventure4.GameController
{
    public class GameController
    {
        private Game currentGame;

        public GameController(Game game) { currentGame = game; }

        //Move Actor From 1 Room to Another Room
        public ActionResult AttemptoChangeRooms(ActionRequest<Actor, Room, Room> request)
        {
            RuleResult rulling = RulesEngine.CanChangeRooms(request.Subject, request.DirectObject, request.IndirectObject);
            ActionResult result = new ActionResult();
            result.Ruling = rulling;
            if(rulling.Success || !request.FollowRules)
            {
                result.Messages.AddRange(TaskManager.ChangeRooms(request.Subject, request.DirectObject, currentGame));
            }
            return result;
        }
    }
}
