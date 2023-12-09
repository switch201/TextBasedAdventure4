using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;

namespace TextBasedAdventure4.Games.Decks
{
    public class Deck : GameObject
    {
        [JsonIgnore]
        public List<Card> Cards = new List<Card>() { };
    }
}
