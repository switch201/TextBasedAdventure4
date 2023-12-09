using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameControllers
{
    public class TaskManager
    {
        public static List<string> InspectObject(Actor subject, GameObject gameObject )
        {
            return new List<string>()
            {
                $"{subject.Name} inspects {gameObject.Name}. It's {gameObject.Description}"
            };
        }
    }
}
