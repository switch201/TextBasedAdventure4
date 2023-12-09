using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;

namespace TextBasedAdventure4.Games.Decks
{
    public class Card : GameObject
    {
        public CardEffects Effects { get; }

        public int Level { get;  }
    }
}
