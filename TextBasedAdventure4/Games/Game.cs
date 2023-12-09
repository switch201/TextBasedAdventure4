using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TextBasedAdventure4.GameObjects.Factories;
using TextBasedAdventure4.Games.Rooms;
using TextBasedAdventure4.Games.Actors;

namespace TextBasedAdventure4.GameObjects
{
    public class Game
    {
        public Room StartingRoom{ get; set; }

        public Player player;
    }
}
