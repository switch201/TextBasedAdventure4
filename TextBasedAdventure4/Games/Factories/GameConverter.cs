using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TextBasedAdventure4.Games.Factories
{
    internal class GameConverter : JsonConverter<Game>
    {
        public override Game? ReadJson(JsonReader reader, Type objectType, Game? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var game = new Game();
            JObject jObject = JObject.Load(reader);
            foreach (string room in jObject["Rooms"])
            {
                game.AddRoom(GameObjectFactory.CreateRoom(room));
            }

            foreach (var connection in jObject["Connections"])
            {
                var room1 = game.Rooms.Single(x => x.Name == (string)connection["Room1"]);
                var room2 = game.Rooms.Single(x => x.Name == (string)connection["Room2"]);
                room1.SetExit((string)connection["ExitDirection"], room2);
                room2.SetExit((string)connection["EnterDirection"], room1);
            }

            return game;
        }

        public override void WriteJson(JsonWriter writer, Game? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
