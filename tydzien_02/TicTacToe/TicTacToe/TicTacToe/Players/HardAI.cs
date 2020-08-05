using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Players
{
    class HardAI : AI
    {
        public HardAI()
        {
            MyDifficulty = Difficulty.Hard;
        }
        public override Difficulty MyDifficulty { get; }
    }
}
