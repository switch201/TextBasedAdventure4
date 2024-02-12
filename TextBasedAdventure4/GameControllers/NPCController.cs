using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameControllers
{
    public class NPCController
    {
        private Room currentRoom;
        public NPCController(Room currentRoom)
        {
            this.currentRoom = currentRoom;
        }

        public List<ConsoleOutput> ListNPCs()
        {
            return this.currentRoom.GetNpcs();
        }
    }
}
