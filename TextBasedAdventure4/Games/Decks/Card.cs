using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.GameObjects;

namespace TextBasedAdventure4.Games.Decks
{
    public enum CardType
    {
        Attack,
        Defense,
        Effect,
    }
    public class Card : GameObject
    {
        public CardEffect CardEffects { get; set; }

        public CardType CardType { get; set; }

        public int Level { get;  }

        public int Range { get; set; }

        internal ConsoleColor GetColor()
        {
            if(CardType == CardType.Defense)
            {
                return ConsoleColor.Green;
            }
            if(CardType == CardType.Attack)
            {
                return ConsoleColor.Red;
            }
            if(CardType == CardType.Effect)
            {
                return ConsoleColor.Blue;
            }
            return ConsoleColor.White;
        }
    }
}