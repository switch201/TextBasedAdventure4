using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.Games.Decks;

namespace TextBasedAdventure4.GameControllers.RuleEngines
{
    public static class CardRules
    {
        public static RuleResult HasActionpoints(Actor actor, Card card)
        {
            var result = new RuleResult() { Success = true };
            if (actor.CurrentActionPoints < card.CardEffects.Cost)
            {
                result.Success = false;
                result.Messages.Add(new ConsoleOutput("You Do not have enough action points to play" +
                    "that card.\n"));
                result.Messages.Add(new ConsoleOutput($"Action Points: {actor.CurrentActionPoints}\n", ConsoleColor.Green));
                result.Messages.Add(new ConsoleOutput($"Card Cost: {card.CardEffects.Cost}", ConsoleColor.Red));
            }
            return result;
        }

        public static RuleResult IsInRange((int, int) start , (int, int) end, Card card)
        {
            var result = new RuleResult() { Success = true };
            // Calculate the distance between start and end
            int dx = Math.Abs(start.Item1 - end.Item1);
            int dy = Math.Abs(start.Item2 - end.Item2);

            if(dx + dy > card.Range)
            {
                result.Messages.Add(new ConsoleOutput("You are not in range to play that Card\n"));
                result.Messages.Add(new ConsoleOutput($"Card Range: {card.Range}", ConsoleColor.Green));
                result.Messages.Add(new ConsoleOutput($"Distance: {dx + dy}", ConsoleColor.Red));
            }
            return result;
        }

    }
}
