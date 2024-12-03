using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class ClassicModeState : GameState
    {
        public ClassicModeState(int rows, int cols) : base(rows, cols)
        {
            AddSnake();
            AddFood();
        }
    }
}
