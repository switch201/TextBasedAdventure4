using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Decks;

namespace TextBasedAdventure4.Games.Actors
{
    public abstract class Actor : GameObject
    {
        public int ActionPoints;

        public int Health;

        public int HandLimit;

        [JsonIgnore]
        public ActorDeck Deck;

        public int MaxMovement;

        public int CurrentMovement;
    }
}
