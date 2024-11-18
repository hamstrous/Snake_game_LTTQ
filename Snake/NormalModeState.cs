using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class NormalModeState : GameState
    {
        public NormalModeState(int rows, int cols) : base(rows, cols)
        {
            AddSnake();
            AddFood();
        }
    }
}
