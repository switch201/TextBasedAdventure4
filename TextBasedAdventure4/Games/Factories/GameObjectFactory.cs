using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Decks;
using TextBasedAdventure4.Games.Factories;
using TextBasedAdventure4.Games.Rooms;

namespace TextBasedAdventure4.GameObjects.Factories
{
    //Welcome to the factory my young lad. Tis a magical place.
    //This is where all gameObjects are created into the world.
    //Not a game object exists out there that doesn't pass through these doors.
    public static class GameObjectFactory
    {
        private static string baseLevelPath = "Content";

        public static Room CreateRoom(string objectName)
        {
            return JsonConvert.DeserializeObject<Room>(Util.Readfile($"{baseLevelPath}/Rooms/{objectName}.json"), new RoomConverter());
        }

        public static NPC CreateNPC(string actorName)
        {
            return JsonConvert.DeserializeObject<NPC>(Util.Readfile($"{baseLevelPath}/Actors/{actorName}.json"), new NPCConverter());
        }

        private static Player CreatePlayer(string actorName)
        {
            return JsonConvert.DeserializeObject<Player>(Util.Readfile($"{baseLevelPath}/Actors/{actorName}.json"), new PlayerConverter());
        }
        public static Player CreatePlayer()
        {
            return GameObjectFactory.CreatePlayer("Player");
        }

        public static Game CreateGame(string objectName)
        {
            return JsonConvert.DeserializeObject<Game>(Util.Readfile($"{baseLevelPath}/{objectName}.json"), new GameConverter());
        }

        public static Deck CreateDeck(string deckName)
        {
            return JsonConvert.DeserializeObject<Deck>(Util.Readfile($"{baseLevelPath}/Decks/{deckName}.json"), new DeckConverter());
        }

        public static Card CreateCard(string cardName)
        {
            return JsonConvert.DeserializeObject<Card>(Util.Readfile($"{baseLevelPath}/Cards/{cardName}.json"), new CardConverter());
        }
    }
}
