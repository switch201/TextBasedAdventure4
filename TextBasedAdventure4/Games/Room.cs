using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameObjects
{
    public class Room : GameObject
    {
        public List<GameObject> Contents = new List<GameObject>();

        private Dictionary<string, Room> Exits = new Dictionary<string, Room>();

        public void AddObject(GameObject obj)
        {
            Contents.Add(obj);
        }

        public void SetExit(string direction, Room room)
        {
            Exits.Add(direction, room);
        }

        public bool IsAdjacent(Room room)
        {
            return Exits.Values.Any(x => x == room);
        }

    }
}
