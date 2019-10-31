using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerEvaluatorLibrary
{
    class Player
    {
        private int playerID;

        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        private string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

    }
}
