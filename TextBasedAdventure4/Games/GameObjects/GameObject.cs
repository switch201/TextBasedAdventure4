using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.Games.GameObjects
{
    public abstract class GameObject
    {
        public string Description { get; set; }

        public string Name { get; set; }
    }
}
