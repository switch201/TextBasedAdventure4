using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Decks;
using TextBasedAdventure4.Games.GameObjects;

namespace TextBasedAdventure4.Games.Actors
{
    public abstract class Actor : GameObject
    {
        public int MaxActionPoints;

        public int CurrentActionPoints;

        public int CurrentHealth;

        public int MaxHealth;

        public int HandLimit;

        [JsonIgnore]
        public ActorDeck Deck;

        public int MaxMovement;

        public int CurrentMovement;
    }
}
