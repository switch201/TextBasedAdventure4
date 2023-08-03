using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games;

namespace TextBasedAdventure4.GameController
{
    public class ActionRequest<T, K, I>
        where T : GameObject
        where K : GameObject
        where I : GameObject
    {
        public T Subject;

        public K DirectObject;

        public I IndirectObject;

        public bool FollowRules;
    }
}
