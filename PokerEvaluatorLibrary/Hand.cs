using System.Diagnostics.Eventing.Reader;


namespace PokerEvaluatorLibrary.Classes
{
    public class Hand
    {
        public string playerName;
        public char[] suits;
        public int[] nums;
        public bool isFlush;
        public bool isTrips;
        public bool isPair;
        public bool isHighCard;
        public int keyNumber;
        public int handValue;
       
       public Hand(string aName, string[] aCards)
        {
             playerName = aName;
            suits = StaticHandEvaluationTools.ParseCharsToSuits(aCards);
            nums = StaticHandEvaluationTools.ParseNumbersToInts(aCards);
            isFlush = StaticHandEvaluationTools.IsFlush(suits);
            isTrips = StaticHandEvaluationTools.IsTrips(nums);
            isPair = StaticHandEvaluationTools.IsPair(nums);

            if (!isFlush && !isTrips && !isPair)
            {
                isHighCard = true;
                keyNumber = StaticHandEvaluationTools.HighCard(nums);
            }

            if (isFlush)
            {
                keyNumber = StaticHandEvaluationTools.HighCard(nums);
            }

            if (isTrips)
            {
                keyNumber = StaticHandEvaluationTools.FindTripsTopCard(nums);
            }

            if (isPair)
            {
                keyNumber = StaticHandEvaluationTools.FindPairTopCard(nums);
            }

            handValue = CreateHandIntValue.CalculateHandValue(isFlush, isTrips, isPair, keyNumber, nums);
       }
        

    }
}
