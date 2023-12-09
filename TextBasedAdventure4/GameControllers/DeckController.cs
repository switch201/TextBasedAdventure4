using TextBasedAdventure4.GameObjects;
using TextBasedAdventure4.Games.Decks;
using System.Linq;

namespace TextBasedAdventure4.GameControllers
{
    public class DeckController
    {
        private Game currentGame;

        private List<Card> playingDeck = new List<Card>();

        private List<Card> discardPile = new List<Card>();

        private List<Card> playerHand = new List<Card>();
        public DeckController(Game game)
        {
            currentGame = game;
        }

        public void StartBattle()
        {
            // Get Most Current PlayerDeck
            playingDeck = currentGame.player.Deck.SelectMany(x => x.Cards).ToList();
            Util.Shuffle(playingDeck);
        }

        public void StartTurn()
        {
            DrawFromPlayerDeck(currentGame.player.HandLimit);
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
            return playingDeck.SelectMany(y => new List<ConsoleOutput>() { y.Name, new ConsoleOutput("\n") }).ToList();
        }

        public List<ConsoleOutput> GetPlayerHand()
        {
            return playerHand.SelectMany(y => new List<ConsoleOutput>() { y.Name, new ConsoleOutput("\n") }).ToList();
        }

        public List<ConsoleOutput> GetPlayerHandCardNames()
        {
            return playerHand.Select(y => y.Name).ToList();
        }

        public List<ConsoleOutput> GetPlayerDeckNames()
        {
            return currentGame.player.Deck.Select(x => x.Name).ToList();
        }

        public void DrawFromPlayerDeck(int cardCount)
        {
            for(int i = 0; i < cardCount; i++)
            {
                if(playingDeck.Count == 0)
                {
                    ReseadPlayerDeck();
                }
                playerHand.Add(playingDeck.First());
                playingDeck.RemoveAt(0);
            }
        }

        public List<ConsoleOutput> GetCardInfo()
        {
            return new List<ConsoleOutput>();
        }
    }
}