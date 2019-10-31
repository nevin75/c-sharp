using System;
using static System.Math;

namespace PokerEvaluatorLibrary.Classes
{
    public class CreateHandIntValue
    {
        public static int CalculateHandValue(bool isFlush, bool isTrips, bool isPair, int keycard, int[] cardValues)
        {
            /*Converts the player's hand into an integer based on it's merit in a poker game
             * create a handvalue that is based on multiplying each card value by its value to the hand
             * Flush high cards are multiplied by 10 to the power of 7
             * Trip sets are multiplied by 10 to the power of 6
             * Pairs are multiplied by 10 to the power of 5
             * High cards are multiplied by 10 to the power of 4
             * then,
             * the lowest kicker is multiplied by 10 to the power of 0
             * the second lowest kicker is multiplied by 10 to the power of 1
             * and so on... 
             * cards used as the top card in a set of pairs or trips are ignored...
             * but they are ignored by competitors too, if there's a tie
             */
          
            double handValue = 0;
            if (isFlush)
                handValue = handValue + (keycard * Pow(10, (cardValues.Length+2)));
            else if (isTrips)
                handValue = handValue + (keycard * Pow(10, (cardValues.Length+1)));
            else if (isPair)
                handValue = handValue + (keycard * Pow(10, (cardValues.Length)));
            else
                handValue = handValue + (keycard * Pow(10, (cardValues.Length - 1)));
            for (int i = 0; i <= cardValues.Length - 1; i++)
            {
                if (cardValues[i] != keycard)
                    handValue = (handValue + (cardValues[i] * Pow(10, i)));
            }
            return Convert.ToInt32(handValue);
        }
    }
}