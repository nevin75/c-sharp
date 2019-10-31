using System;
using static CardGame.Card;

namespace CardGame
{


    public class Card : IComparable
    {
        public enum SuitEnum { Hearts, Diamonds, Clubs, Spades };
        public enum NumberEnum { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
        public SuitEnum Suit { get; set; }
        public NumberEnum NumberValue { get; set; }

        // Default constructor - can't assign empty values to CardSuit and CardNumber so we need to throw a warning. However, we can't NOT have a default constructor.
        public Card()
        {
            throw new Exception("No such thing as a null card. Supply CardNumber and Suit.");
        }
        // The constructor we WANT to use is the one with card number and suit.
        public Card(NumberEnum cardNumber, SuitEnum cardSuit)
        {
            this.NumberValue = cardNumber;
            this.Suit = cardSuit;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) throw new Exception("Another valid card object is required for comparison.");
            Card OtherCard = obj as Card;

            if (OtherCard.NumberValue == this.NumberValue)
            {
                // Note: We can't have identical cards, assuming a single deck is in use.
                if (OtherCard.Suit != this.Suit)
                {
                    return 0;
                }
                else
                {
                    throw new Exception("Somebody's cheating. Both cards are the same number and suit!");
                }
            }
            // It's okay if the suits match but the cards are different.
            if (OtherCard.NumberValue < this.NumberValue) return -1;
            if (OtherCard.NumberValue > this.NumberValue) return 1;
            return 0;
        }
    }

    public class Hand : IComparable
    {
        public enum HandRankEnum { HighCard, Pair }
        public HandRankEnum HandRank { get; set; }
        public enum OutcomeEnum { Wins, Ties, Loses }
        public Card.NumberEnum HandHighCard { get; set; }
        public OutcomeEnum HandOutcome { get; set; }

        public Hand()
        {
            throw new NotImplementedException();
        }
        public Hand(Card card1, Card card2)
        {
            int result = 0;
            try
            {
                result = card1.CompareTo(card2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            switch (result)
            {
                case -1:
                    this.HandRank = HandRankEnum.HighCard;
                    this.HandHighCard = card2.NumberValue;
                    break;
                case 1:
                    this.HandRank = HandRankEnum.Pair;
                    this.HandHighCard = card1.NumberValue;
                    break;
                default:
                    this.HandRank = HandRankEnum.Pair;
                    this.HandHighCard = card1.NumberValue;
                    break;
            }


        }

        public int CompareTo(object obj)
        {
            if (obj == null) throw new Exception("Another valid hand object is required for comparison.");
            Hand otherHand = obj as Hand;
            {
                if (this.HandRank > otherHand.HandRank) return 1;
                if (this.HandRank < otherHand.HandRank) return -1;
                if (this.HandRank == otherHand.HandRank)
                {
                    if (this.HandHighCard > otherHand.HandHighCard) return 1;
                    if (this.HandHighCard < otherHand.HandHighCard) return -1;
                    if (this.HandHighCard == otherHand.HandHighCard) return 0;
                }
            }

            return 0;
        }
    }
    static class Program
    {

        // So your card class is going to look like this:


        

        static void Main(string[] args)
        {

            Card H1card1 = new Card(NumberEnum.Four, Card.SuitEnum.Diamonds);
            Card H1card2 = new Card(NumberEnum.Eight, Card.SuitEnum.Hearts);
            Hand hand1 = new Hand(H1card1, H1card2);

            Card H2card1 = new Card(NumberEnum.Seven, Card.SuitEnum.Diamonds);
            Card H2card2 = new Card(NumberEnum.Seven, Card.SuitEnum.Hearts);
            Hand hand2 = new Hand(H2card1, H2card2);


            

            int result = hand1.CompareTo(hand2);
            switch (result)
            {
                case 1:
                    hand1.HandOutcome = Hand.OutcomeEnum.Wins;
                    hand2.HandOutcome = Hand.OutcomeEnum.Loses;
                    break;
                case -1:
                    hand1.HandOutcome = Hand.OutcomeEnum.Loses;
                    hand2.HandOutcome = Hand.OutcomeEnum.Wins;
                    break;
                default:
                    hand1.HandOutcome = Hand.OutcomeEnum.Ties;
                    hand2.HandOutcome = Hand.OutcomeEnum.Ties;
                    break;
            }

            // Now write some code to output the result of the hand.
        }
    }
}
