using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Players
{
    class EasyAI: AI
    {
        public EasyAI()
        {
            MyDifficulty = Difficulty.Easy;
        }
        public override Difficulty MyDifficulty { get; }
    }
}
