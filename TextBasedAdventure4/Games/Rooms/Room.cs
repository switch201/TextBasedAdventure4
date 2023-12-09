using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;

namespace TextBasedAdventure4.Games.Rooms
{
    public class Room : GameObject
    {
        [JsonIgnore]
        public List<List<Space>> Spaces;

        public List<ConsoleOutput> GetRoomLayout()
        {
            var grid = Spaces.Select(row => row.Select(space => space.getSymbol()).ToList()).ToList();
            var result = new List<ConsoleOutput>();
            result.Add(new ConsoleOutput("You take a look around the room\n"));
            foreach (var row in grid)
            {
                row.ForEach(x => result.Add(x));
                result.Add(new ConsoleOutput("\n"));
            }
            return result;
        }
    }
}
