using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Factories;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameObjects.Factories
{
    internal class RoomConverter : GameObjectConverter<Room>
    {
        public override Room ReadJson(JsonReader reader, Type objectType, Room existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            Room room = CreateGameObject(jObject);
            List<List<string>> spaceRefs = ConvertSpaces(jObject["Spaces"]);
            List<List<Space>> spaces = new List<List<Space>>() { };                                     
            foreach (List<string> row in spaceRefs)
            {
                spaces.Add(new List<Space>());
                foreach(string spaceRef in row)
                {
                    spaces.Last().Add(CreateSpace(spaceRef));
                }
            }
            room.Spaces = spaces;
            return room;
        }

        public override void WriteJson(JsonWriter writer, Room? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        static List<List<string>> ConvertSpaces(JToken spacesToken)
        {
            if (spacesToken is JArray spacesArray)
            {
                // Convert each JArray to a List<string> and add to the result list
                return spacesArray.Select(row => row.Select(cell => cell.ToString()).ToList()).ToList();
            }

            return new List<List<string>>(); // Return an empty list if "Spaces" is not an array
        }

        static Space CreateSpace(string spaceRef)
        {
            var space = new Space();
            if (spaceRef == "")
            {
                return space;
            }
            if (spaceRef == "P")
            {
                space.Ocupent = GameObjectFactory.CreatePlayer();
            }
            else
            {
                space.Ocupent = GameObjectFactory.CreateNPC(spaceRef);
            }
            return space;
        }
    }
}
