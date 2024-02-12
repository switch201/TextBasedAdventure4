using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.GameObjects;

namespace TextBasedAdventure4.GameControllers.GameActions
{
    public abstract class GameAction
    {
        public abstract List<string> keyWords { get; }

        public abstract List<ConsoleOutput> RespondToInput(GameController controller, List<string> seperatedWords);

        
        //// Returns all game objects that the player has context for the given game state
        //// Player wouldn't have context to enemy in another room for example, but would for enemy
        //// in same room.
        //private List<GameObject> GetContextualObjects(GameController controller)
        //{

        //}

        //public GameObject GetContextualGameObject(string name, GameController controller)
        //{
        //    return GetContextualObjects(name, controller).Where(x => x.Name == name).FirstOrDefault();
        //}

    }
}
