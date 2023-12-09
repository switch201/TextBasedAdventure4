using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Decks;

namespace TextBasedAdventure4.Games.Factories
{
    internal class CardConverter : GameObjectConverter<Card>
    {
        public override Card? ReadJson(JsonReader reader, Type objectType, Card? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var card = CreateGameObject(jObject);
            return card;
        }

        public override void WriteJson(JsonWriter writer, Card? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
