using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4
{
    public class ConsoleOutput
    {
        public string Message;

        public ConsoleColor Color;
        public ConsoleOutput(string message)
        {
            Message = message;
            Color = ConsoleColor.White;
        }

        public ConsoleOutput(string message, ConsoleColor color)
        {
            Message = message;
            Color = color;
        }
    }
}
