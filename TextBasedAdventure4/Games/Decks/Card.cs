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
        public CardEffects CardEffects { get; set; }

        public int Level { get;  }

        public List<ConsoleOutput> GetDescription()
        {
            return new List<ConsoleOutput>()
            {
                new ConsoleOutput($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n", ConsoleColor.Green),
                new ConsoleOutput($"Card Name: {Name.Message}\n"),
                new ConsoleOutput($"Card Description: {Description.Message}\n"),
                new ConsoleOutput($"Cost: : {CardEffects.Cost}\n", ConsoleColor.Yellow),
                new ConsoleOutput($"Damage: : {CardEffects.Damage}\n", ConsoleColor.Red),
                new ConsoleOutput($"Defense: : {CardEffects.Block}\n", ConsoleColor.Blue),
                new ConsoleOutput($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n", ConsoleColor.Green)
            };
        }
    }
}