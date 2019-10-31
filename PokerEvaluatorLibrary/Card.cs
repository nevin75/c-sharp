using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerEvaluatorLibrary
{
    class Card : IComparable
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
