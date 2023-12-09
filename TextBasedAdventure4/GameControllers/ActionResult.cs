using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.GameControllers.RuleEngines;

namespace TextBasedAdventure4.GameControllers
{
    public class ActionResult
    {
        public List<string> Messages { get; set; }

        public RuleResult Ruling { get; set; }

        public ActionResult()
        {
            Messages = new List<string>();
        }

    }
}
