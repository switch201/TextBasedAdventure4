using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameControllers.RuleEngines;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameControllers
{
    public class RoomController
    {
        private Game currentGame;

        private Room currentRoom;

        public RoomController(Game currentGame)
        {
            this.currentGame = currentGame;
            this.currentRoom = currentGame.StartingRoom;
        }

        public List<ConsoleOutput> GetRoomLayout()
        {
            return currentRoom.GetRoomLayout();
        }

        public (int, int) GetPlayerSpace()
        {
            var index = currentRoom.Spaces
            .SelectMany((row, rowIndex) => row.Select((col, colIndex) => new { rowIndex, colIndex, col }))
            .FirstOrDefault(item => item.col.Ocupent is Player);
            return (index.rowIndex, index.colIndex);
        }

        public void ChangeSpace((int, int) startingSpaceCords, (int, int) endingSpaceCords)
        {
            var startingSpace = currentRoom.Spaces.ElementAt(startingSpaceCords.Item1).ElementAt(startingSpaceCords.Item2);
            var endingSpace = currentRoom.Spaces.ElementAt(endingSpaceCords.Item1).ElementAt(endingSpaceCords.Item2);
            if (startingSpace.Ocupent == null)
            {
                return;
            }
            if(endingSpace.Ocupent != null)
            {
                return;
            }
            endingSpace.Ocupent = startingSpace.Ocupent;
            startingSpace.Ocupent = null;
        }
    }
}
