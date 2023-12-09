using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TextBasedAdventure4.Games.Actors;

namespace TextBasedAdventure4.GameObjects.Factories
{
    internal class GameConverter : JsonConverter<Game>
    {
        public override Game? ReadJson(JsonReader reader, Type objectType, Game? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var game = new Game();
            JObject jObject = JObject.Load(reader);
            string startingRoom = jObject["StartingRoom"].ToString();
            var room = GameObjectFactory.CreateRoom(startingRoom);
            //BAD
            var player = room.Spaces.SelectMany(x => x.Where(y => y.Ocupent is Player).ToList()).Single();
            game.player = (Player)player.Ocupent;
            game.StartingRoom = room;
            return game;
        }

        public override void WriteJson(JsonWriter writer, Game? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
