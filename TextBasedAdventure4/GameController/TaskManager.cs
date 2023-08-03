using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games;

namespace TextBasedAdventure4.GameController
{
    public class TaskManager
    {
        public static List<string> ChangeRooms(Actor gameObject,Room targetRoom, Game game)
        {
            game.GetObjectsRoom(gameObject).Contents.Remove(gameObject);
            targetRoom.Contents.Add(gameObject);
            return new List<string>()
            {
                $"{gameObject.GetName()} moves into the {targetRoom.GetName()}"
            };
        }
    }
}
