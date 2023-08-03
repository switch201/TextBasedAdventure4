using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameObjects
{
    public abstract class GameObject
    {
        private string Description = "";

        public string Name = "";

        public string GetName() {
            return Name;
        }
    }
}
