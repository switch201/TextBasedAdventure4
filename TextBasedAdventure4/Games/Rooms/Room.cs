using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.GameObjects;

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
            foreach (var row in grid)
            {
                row.ForEach(x => result.Add(x));
                result.Add(new ConsoleOutput("\n"));
            }
            return result;
        }

        public List<ConsoleOutput> GetNpcs()
        {
            return Spaces.SelectMany(x => x)
                .Where(x => x.Ocupent is NPC)
                .Select(x => new ConsoleOutput(x.Ocupent.Name + "\n"))
                .ToList();
        }

        public List<NPC> GetNpcObjects()
        {
            return Spaces.SelectMany(x => x)
                .Where(x => x.Ocupent is NPC)
                .Select(x => (NPC)x.Ocupent)
                .ToList();
        }
    }
}
