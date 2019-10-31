using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerEvaluatorLibrary.Classes
{
    public class StaticHandEvaluationTools
    {
        //determine the card value that is making a pair
        public static int FindPairTopCard(int[] arrayToReview)
        {
            Array.Sort(arrayToReview);
            for (int i = 0; i <= arrayToReview.Length - 2; i++)
            {
                if (arrayToReview[i] == arrayToReview[i + 1])
                    return arrayToReview[i];
            }
            return 0;
        }

        public static string[] ConvertStringsToArray(string v1, string v2, string v3, string v4, string v5)
        {
            string[] cardsInArray = { v1, v2, v3, v4, v5 } ;
            return cardsInArray;
        }

        public static int FindTripsTopCard(int[] arrayToReview)
        {
            //determine the card value that is making three of a kind
            Array.Sort(arrayToReview);
            for (int i = 0; i <= arrayToReview.Length - 3; i++)
            {
                if ((arrayToReview[i] == arrayToReview[i + 1]) && (arrayToReview[i] == arrayToReview[i + 2]))
                    return arrayToReview[i];
            }
            return 0;
        }

        public static int HighCard(int[] arrayToReview)
        {
            //determine the highest card value when there is no matching set or flush
            int HighCard = 0;
            for (int i = 0; i <= arrayToReview.Length - 1; i++)
            {
                if (arrayToReview[i] > HighCard)
                    HighCard = arrayToReview[i];
            }
            return (HighCard);
         }

        public static bool IsFlush(char[] arrayForCheck)
        {
            //determine if the hand contains a flush
            int LoopCount = 0;
                for (int i = 0; i <= arrayForCheck.Length - 2; i++)
                {
                    if (arrayForCheck[i] == arrayForCheck[i + 1])
                    {
                        LoopCount++;
                        if (LoopCount == arrayForCheck.Length - 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
         }

        public static bool IsPair(int[] arrayToReview)
        {
            //determine if the hand contains a pair
            Array.Sort(arrayToReview);
            for (int i = 0; i <= arrayToReview.Length; i++)
            {
                for (int j = i + 1; j <= arrayToReview.Length - 1; j++)
                {
                    if (arrayToReview[i] == arrayToReview[j])
                        return true;
                }
            }
            return false;
        }

        public static bool IsTrips(int[] arrayToReview)
        {
            //determine if the hand contains three of a kind
            Array.Sort(arrayToReview);
            for (int i = 0; i <= arrayToReview.Length - 3; i++)
            {
                if ((arrayToReview[i] == arrayToReview[i + 1]) && (arrayToReview[i] == arrayToReview[i + 2]))
                    return true;
            }
            return false;
         }

        public static char[] ParseCharsToSuits(string[] startArray)
        {
            //convert an array of cards to just represent suits
            char[] suits = new char[startArray.Length];
            char[] trimChars = { '0', '9', '8', '7', '6', '5', '4', '3', '2', '1' };
            for (int i = 0; i <= startArray.Length - 1; i++)
            {
                suits[i] = Char.ToUpper(Char.Parse(startArray[i].Trim(trimChars)));
            }
            return suits;
        }

        public static int[] ParseNumbersToInts(string[] startArray)
        {
            //convert an array of cards to just represent values
            int[] values = new int[startArray.Length];
            string interim;
            char[] trimChars = { 'H', 'h', 'C', 'c', 'D', 'd', 'S', 's' };
            for (int i = 0; i <= startArray.Length - 1; i++)
            {
                interim = startArray[i].Trim(trimChars);
                values[i] = Int32.Parse(interim);
            //convert 1 (ace) to 14
            if (values[i] == 1)
                    values[i] = 14;
            }
            Array.Sort(values);
            return values;
        }
    }
}

