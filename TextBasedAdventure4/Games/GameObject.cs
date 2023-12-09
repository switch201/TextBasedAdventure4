using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameObjects
{
    public abstract class GameObject
    {
        [JsonIgnore]
        public ConsoleOutput Description { get; set; }

        [JsonIgnore]
        public ConsoleOutput Name { get; set; }
    }
}
