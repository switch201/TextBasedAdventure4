using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects.Factories;
using TextBasedAdventure4.Games.Decks;

namespace TextBasedAdventure4.Games.Factories
{
    internal class DeckConverter : GameObjectConverter<Deck>
    {
        public override Deck? ReadJson(JsonReader reader, Type objectType, Deck? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var deck = CreateGameObject(jObject);
            foreach (string cardName in jObject["Cards"])
            {
                deck.Cards.Add(GameObjectFactory.CreateCard(cardName));
            }
            return deck;
        }

        public override void WriteJson(JsonWriter writer, Deck? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
