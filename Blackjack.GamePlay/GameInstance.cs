using Blackjack.Data;
using Blackjack.Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.GamePlay
{
    public partial class GameInstance
    {
        private Player Player { get; set; }
        private Dealer Dealer { get; set; }
        public Deck Deck { get; set; }


        public GameInstance()
        {
            Player = new Player();
            Dealer = new Dealer();
            Deck = new Deck();
        }

        public bool SetBetAmount(float betAmount)
        {
            return Player.PlaceBet(betAmount);
        }

        public float GetPlayerCash()
        {
            return Player.Cash;
        }

        public bool IsBettingAllowed()
        {
            return Player.CurrentBet == null;
        }

        public void UserHit(UserType user)
        {
            HitUser(UserType.Player);
        }

        public bool HasUserBusted(UserType user)
        {
            return user == UserType.Player ? Player.HasPlayerBusted() : Dealer.HasDealerBusted();
        }

        private void HitUser(UserType user)
        {
            if (user == UserType.Player)
            {
                Player.CurrentHand.AddCard(Deck.GetCard());
            }
            else
            {
                Dealer.CurrentHand.AddCard(Deck.GetCard());
            }
        }

        public void InitDealCards()
        {
            HitUser(UserType.Player);
            HitUser(UserType.Player);

            HitUser(UserType.Dealer);
            HitUser(UserType.Dealer);
        }

        public string GetPlayerCardCount()
        {
            return Player.CurrentHand.GetTotal().ToString();
        }

        public string GetDealerCardCount()
        {
            return Dealer.CurrentHand.GetTotal().ToString();
        }

        public void NextRound()
        {
            Player.ResetRound();

            Dealer.ResetRound();
        }

        public GameResult DealersTurn()
        {
            while (Dealer.CurrentHand.GetTotal() < 17)
            {
                HitUser(UserType.Dealer);
            }

            if (Dealer.CurrentHand.GetTotal() == Player.CurrentHand.GetTotal())
            {
                return GameResult.Standoff;
            }

            if (Dealer.HasDealerBusted())
            {
                return GameResult.Win;
            }

            return Dealer.CurrentHand.GetTotal() > Player.CurrentHand.GetTotal() ? GameResult.Loss : GameResult.Win;
        }

        public void Payout(GameResult result)
        {
            if (result != GameResult.Win && result != GameResult.PlayerBlackjack) return;
            
            var payoutAmt = Player.CurrentBet;

            if (result == GameResult.PlayerBlackjack)
            {
                payoutAmt *= 1.5f;
            }

            Player.CollectWinnings(payoutAmt);
        }

        public List<Card> GetPlayerCardList()
        {
            return Player.CurrentHand.HandCards.Select(card => card).ToList();
        }
        public List<Card> GetDealerCardList()
        {
            return Dealer.CurrentHand.HandCards.Select(card => card).ToList();
        }

        public string GetCardBackImage()
        {
            return Player.CurrentHand.HandCards.FirstOrDefault()?.BackImagePath;
        }

        public bool ShouldCardsBeDisplayed(UserType user)
        {
            if (user == UserType.Player)
            {
                return true;
            }

            if (Dealer.HasDealerBusted())
            {
                return true;
            }
            
            var cardCount = Dealer.CurrentHand.HandCards.Count;

            return cardCount == 21;
        }
    }
}
