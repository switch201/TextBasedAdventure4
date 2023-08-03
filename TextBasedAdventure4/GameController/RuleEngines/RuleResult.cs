using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameController.RuleEngines
{
    public class RuleResult
    {
        public bool Success { get; set; }

        public List<string> Messages { get; set; }

        public RuleResult()
        {
            Messages = new List<string>();
        }
    }
}
