using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Actors;

namespace TextBasedAdventure4.Games.Rooms
{
    public class Space
    {
        public Actor? Ocupent;

        public ConsoleOutput getSymbol()
        {
            if(Ocupent == null)
            {
                return new ConsoleOutput("[ ]");
            }
            if(Ocupent is Player){
                return new ConsoleOutput("[P]", ConsoleColor.Green);
            }
            else
            {
                return new ConsoleOutput("[E]", ConsoleColor.Red);
            }
        }
    }
}
