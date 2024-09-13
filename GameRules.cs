using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_3
{
    public class GameRules
    {
        private readonly string[] _moves;

        public GameRules(string[] moves)
        {
            _moves = moves;
        }

        public bool IsWin(int playerMoveIndex, int computerMoveIndex)
        {
            int half = (_moves.Length ) / 2;
            int distance = (computerMoveIndex - playerMoveIndex + _moves.Length) % _moves.Length;

            return distance <= half;
        }
    }

}