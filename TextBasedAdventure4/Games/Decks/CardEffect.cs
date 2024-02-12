using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Actors;

namespace TextBasedAdventure4.Games.Decks
{
    public class CardEffect
    {
        public int Cost{ get; set; }

        public int Damage { get; set; }

        public int Block { get; set; }

        public string Summonable { get; set; }
    }
}
