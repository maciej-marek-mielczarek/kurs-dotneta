using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Players
{
    abstract class AI: Player
    {
        public abstract Difficulty MyDifficulty { get; }
        public enum Difficulty
        {
            Easy,
            Hard
        }
    }
}
