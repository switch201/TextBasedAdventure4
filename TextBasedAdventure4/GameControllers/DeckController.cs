using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Decks;
using System.Linq;
using TextBasedAdventure4.Games.Actors;
using TextBasedAdventure4.GameControllers.RuleEngines;

namespace TextBasedAdventure4.GameControllers
{
    public class DeckController
    {
        private Actor actor;

        private List<Card> playingDeck = new List<Card>();

        private List<Card> discardPile = new List<Card>();

        private List<Card> playerHand = new List<Card>();
        public DeckController(Actor actor)
        {
            this.actor = actor;
        }

        public void StartBattle()
        {
            // Get Most Current PlayerDeck
            playingDeck = actor.Deck.SelectMany(x => x.Cards).ToList();
            Util.Shuffle(playingDeck);
        }

        public void StartTurn()
        {
            DrawFromPlayerDeck(actor.HandLimit);
        }

        public void EndTrun()
        {
            discardPile.AddRange(playerHand);
            playerHand.Clear();
        }

        public void ReseadPlayerDeck()
        {
            playingDeck.AddRange(discardPile);
            Util.Shuffle(playingDeck);
            discardPile.Clear();
        }

        public List<ConsoleOutput> GetPlayerCardNames()
        {
            return playingDeck.SelectMany(y => new List<ConsoleOutput>() { new ConsoleOutput(y.Name, y.GetColor()), new ConsoleOutput("\n") }).ToList();
        }

        public List<ConsoleOutput> GetPlayerHand()
        {
            return playerHand.SelectMany(y => new List<ConsoleOutput>() { new ConsoleOutput(y.Name, y.GetColor()), new ConsoleOutput("\n") }).ToList();
        }

        public List<ConsoleOutput> GetPlayerHandCardNames()
        {
            return playerHand.Select(x => new ConsoleOutput(x.Name, x.GetColor())).ToList();
        }

        public List<ConsoleOutput> GetPlayerDeckNames()
        {
            return actor.Deck.Select(x => new ConsoleOutput(x.Name)).ToList();
        }

        public void DrawFromPlayerDeck(int cardCount)
        {
            for (int i = 0; i < cardCount; i++)
            {
                if (playingDeck.Count == 0)
                {
                    ReseadPlayerDeck();
                }
                playerHand.Add(playingDeck.First());
                playingDeck.RemoveAt(0);
            }
        }

        private Card GetCardFromHand(string cardName)
        {
            return playerHand.FirstOrDefault(x => x.Name.ToLower() == cardName);
        }
        public List<ConsoleOutput> GetCardInfo(string cardName)
        {
            var ouput = new List<ConsoleOutput>();
            var card = playerHand.FirstOrDefault(x => x.Name.ToLower() == cardName);
            if (card == null)
            {
                card = playingDeck.FirstOrDefault(x => x.Name.ToLower() == cardName);
            }
            if (card == null)
            {
                card = discardPile.FirstOrDefault(x => x.Name.ToLower() == cardName);
            }
            if (card != null)
            {
                return new List<ConsoleOutput>()
            {
                new ConsoleOutput($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n", ConsoleColor.Green),
                new ConsoleOutput($"Card Name: {card.Name}\n"),
                new ConsoleOutput($"Card Description: {card.Description}\n"),
                new ConsoleOutput($"Cost: : {card.CardEffects.Cost}\n", ConsoleColor.Yellow),
                new ConsoleOutput($"Damage: : {card.CardEffects.Damage}\n", ConsoleColor.Red),
                new ConsoleOutput($"Defense: : {card.CardEffects.Block}\n", ConsoleColor.Blue),
                new ConsoleOutput($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n", ConsoleColor.Green)
            };
            }
            return new List<ConsoleOutput>() { new ConsoleOutput("You don't see that card\n") };
        }

        public List<ConsoleOutput> GetDiscardPile()
        {
            return discardPile.Select(x => new ConsoleOutput(x.Name)).ToList();
        }

        public RuleResult CanPlayCard(string cardName)
        {
            return CardRules.HasActionpoints(actor, GetCardFromHand(cardName));
        }

        public void PlayCardIntoDiscard(string cardName)
        {
            var card = GetCardFromHand(cardName);
            discardPile.Add(card);
            playerHand.Remove(card);
        }

        public CardEffect GetCardEffects(string cardName)
        {
            return GetCardFromHand(cardName).CardEffects;
        }
    }
}