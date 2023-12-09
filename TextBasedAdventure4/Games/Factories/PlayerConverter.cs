using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects.Factories;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Decks;

namespace TextBasedAdventure4.Games.Factories
{
    internal class PlayerConverter : GameObjectConverter<Player>
    {
        public override Player? ReadJson(JsonReader reader, Type objectType, Player? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            Player actor = CreateGameObject(jObject);
            string deckRef = (string)jObject["Deck"];
            actor.Deck = new ActorDeck() { GameObjectFactory.CreateDeck(deckRef) };
            // Adding decks for testing
            actor.Deck.Add(GameObjectFactory.CreateDeck("DaggerDeck"));
            return actor;
        }

        public override void WriteJson(JsonWriter writer, Player? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
