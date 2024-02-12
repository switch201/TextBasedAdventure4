using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameControllers.RuleEngines;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.GameObjects.Factories;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Decks;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameControllers
{
    public class RoomController
    {
        private Game currentGame;

        private Room currentRoom;

        public NPCController npcController;

        public RoomController(Game currentGame)
        {
            this.currentGame = currentGame;
            this.currentRoom = currentGame.StartingRoom;
            this.npcController = new NPCController(currentRoom);
        }

        public void AddActorToSpace(string actorName, (int, int) space)
        {
            var target = currentRoom.Spaces.ElementAt(space.Item1).ElementAt(space.Item2);
            target.Ocupent = GameObjectFactory.CreateNPC(actorName);
        }

        public void AttackSpace(int damage, (int, int) space)
        {
            var target = currentRoom.Spaces.ElementAt(space.Item1).ElementAt(space.Item2);
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
            endingSpace.Ocupent = startingSpace.Ocupent;
            startingSpace.Ocupent = null;
            --endingSpace.Ocupent.CurrentMovement;
        }

        public List<ConsoleOutput> AttemptToChangeSpace((int, int) startingSpaceCords, (int, int) endingSpaceCords)
        {
            var ruleResult = CanChangeSpace(startingSpaceCords, endingSpaceCords);
            var output = new List<ConsoleOutput>();
            if (ruleResult.Success)
            {
                ChangeSpace(startingSpaceCords, endingSpaceCords);
                output.Add(new ConsoleOutput($"You moved!\n"));
                return output;
            }
            else
            {
                return ruleResult.Messages;
            }
        }

        private RuleResult CanChangeSpace((int, int) startingSpaceCords, (int, int) endingSpaceCords)
        {
            // Check to see if  starting and ending spaces are on the board
            var result = MoveRules.ValidateCoordinates(currentRoom.Spaces, startingSpaceCords);
            result.Merge(MoveRules.ValidateCoordinates(currentRoom.Spaces, endingSpaceCords));
            if (!result.Success)
            {
                return result;
            }

            // Is there an acotr in the starting space
            var startingSpace = currentRoom.Spaces.ElementAt(startingSpaceCords.Item1).ElementAt(startingSpaceCords.Item2);
            var endingSpace = currentRoom.Spaces.ElementAt(endingSpaceCords.Item1).ElementAt(endingSpaceCords.Item2);
            if(startingSpace.Ocupent == null)
            {
                result.Success = false;
                result.Messages.Add(new ConsoleOutput("There is no one in the starting space to move\n"));
                return result;
            }
            // Is There an actor in the ending space
            if (endingSpace.Ocupent != null)
            {
                result.Success = false;
                result.Messages.Add(new ConsoleOutput("There is something blocking you from moving there\n"));
                return result;
            }

            // Does Actor have enough movement
            result.Merge(MoveRules.HasMovement(startingSpace.Ocupent));

            return result;
        }
    }
}
