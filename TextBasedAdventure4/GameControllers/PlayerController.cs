using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Actors;
namespace TextBasedAdventure4.GameControllers
{
    public class PlayerController
    {
         private Player player;
        public PlayerController(Player player)
        {
            this.player = player;
        }

        public ConsoleOutput GetHealth()
        {
            return new ConsoleOutput($"{player.CurrentHealth} / {player.MaxHealth}\n", ConsoleColor.Red);
        }

        public ConsoleOutput GetMovement()
        {
            return new ConsoleOutput($"{player.CurrentMovement} / {player.MaxMovement}\n", ConsoleColor.Green);
        }

        public ConsoleOutput GetActionPoints()
        {
            return new ConsoleOutput($"{player.CurrentActionPoints} / {player.MaxActionPoints}\n", ConsoleColor.Blue);
        }

        public int getCurrentAction()
        {
            return player.CurrentActionPoints;
        }
    }
}
