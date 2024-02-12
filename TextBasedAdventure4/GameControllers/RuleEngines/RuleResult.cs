using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4.GameControllers.RuleEngines
{
    public class RuleResult
    {
        public bool Success { get; set; }

        public List<ConsoleOutput> Messages { get; set; }

        public RuleResult()
        {
            Messages = new List<ConsoleOutput>();
        }

        // Merge 2 Rule results
        public void Merge(RuleResult mergeItem)
        {
            this.Success = this.Success && mergeItem.Success;
            this.Messages.AddRange(mergeItem.Messages);
        }

        public void Merge(List<RuleResult> mergeList)
        {
            this.Success = this.Success && mergeList.All(x => x.Success);
            this.Messages.AddRange(mergeList.SelectMany(x => x.Messages));
        }
    }
}
