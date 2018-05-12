using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDriver
{
    class Turn
    {
        // this is a very simple object, just used to store data

        public int Player1DiceValue { get; set; }

        public int Player2DiceValue { get; set; }

        public string TurnWinner { get; set; }

        // on monday, we will have two players, each has one dice, each player rolls dide, look at the dice, record what was rolled for each player, determine who was the winner
        // keep track of the amount of wins for player1 and player2 and amount of draws, print all data at the end.
    }
}
