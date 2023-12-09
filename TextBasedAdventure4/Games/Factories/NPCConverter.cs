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
    internal class NPCConverter : GameObjectConverter<NPC>
    {

        public override NPC? ReadJson(JsonReader reader, Type objectType, NPC? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            NPC actor = CreateGameObject(jObject);
            string deckRef = (string)jObject["Deck"];
            actor.Deck = new ActorDeck() { GameObjectFactory.CreateDeck(deckRef) };
            return actor;
        }

        public override void WriteJson(JsonWriter writer, NPC? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
