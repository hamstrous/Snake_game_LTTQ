using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class WallModeState : GameState
    {
        public WallModeState(int rows, int cols) : base(rows, cols)
        {   
            AddSnake();
            AddFood();
        }

        int[] dx = { -1, 1, 0, 0, -1, 1, 1, -1 };
        int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };
        protected bool WallAround(Positions pos)
        {
            for (int i = 0; i < 8; i++)
            {
                Positions nPos = new Positions(pos.Row + dx[i], pos.Column + dy[i]);
                if(!OutsideGrid(nPos) && Grid[nPos.Row, nPos.Column].First.Value == GridValue.Wall)
                {
                    return true;
                }

            }return false;
        }

        protected IEnumerable<Positions> EmptyNotNearWallPosition()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c].Last.Value == GridValue.Empty && !WallAround(new Positions(r, c)))
                    {
                        yield return new Positions(r, c);
                    }
                }
            }
        }

        void AddWall()
        {
            if (random.Next(0, 2) != 0) return;
            List<Positions> empty = new List<Positions>(EmptyNotNearWallPosition());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Column].AddFirst(GridValue.Wall);
            
        }

        public override void Move()
        {
            if (dirChanges.Count > 0)
            {
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();
            }

            Positions newHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newHeadPos);

            if (hit == GridValue.Outside || hit == GridValue.Snake || hit == GridValue.Wall)
            {
                GameOver = true;
                SaveHighScore();
            }
            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (hit == GridValue.Food)
            {
                DeleteObject(newHeadPos);
                AddHead(newHeadPos);
                Score++;
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
                AddFood();
                AddWall();
            }
        }
    }
}
