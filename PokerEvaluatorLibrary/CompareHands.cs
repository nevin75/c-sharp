using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;


namespace PokerEvaluatorLibrary.Classes
{
    public class CompareHands
    {
        //evaluates each hand's integer value and returns the name of the player with the best hand
        public static string FindWinner(Hand[] player)
        {
            string winner = "";
            int highValue = 0;
            for (int i = 0; i <= player.Length - 1; i++)
            {
                if (player[i].handValue > highValue)
                {
                    winner = player[i].playerName;
                    highValue = player[i].handValue;
                }
            }
            return winner;
        }
    }
}