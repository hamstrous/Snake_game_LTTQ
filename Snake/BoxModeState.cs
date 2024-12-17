using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class BoxModeState : GameState
    {
        public BoxModeState(int rows, int cols, int foods) : base(rows, cols, foods)
        {
            AddSnake();
            for(int i=1;i<=FoodCount;i++) AddBox(true);
        }

        protected void MoveBox(Positions pos)
        {
            Grid[pos.Row, pos.Column].AddFirst((GridValue.Box, Directions.Up));
        }

        protected IEnumerable<Positions> EmptyNotNearOutsidePosition()
        {
            for (int r = 1; r < Rows - 1; r++)
            {
                for (int c = 1; c < Cols - 1; c++)
                {
                    if (Grid[r, c].First.Value == GridValue.Empty)
                    {
                        yield return new Positions(r, c);
                    }
                }
            }
        }

        protected void AddBox(bool addGoal)
        {
            List<Positions> empty = new List<Positions>(EmptyNotNearOutsidePosition());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Column].AddFirst((GridValue.Box, Directions.Up));
            if(addGoal) AddGoal();
        }

        protected void AddGoal()
        {
            List<Positions> empty = new List<Positions>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Column].AddFirst((GridValue.Goal, Directions.Up));
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

            if (hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;
                SaveHighScore();
            }
            else if (hit == GridValue.Empty || hit == GridValue.Goal)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (hit == GridValue.Food)
            {
                SoundEffect.PlayEatSound();
                DeleteObject(newHeadPos);
                AddHead(newHeadPos);
                Score++;
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
                AddBox(true);
            }else if (hit == GridValue.Box)
            {
                Positions newBoxPos = newHeadPos.Translate(Dir);
                GridValue boxHit = WillHit(newBoxPos);
                if(boxHit == GridValue.Outside)
                {
                    DeleteObject(newHeadPos);
                    AddBox(false);
                    RemoveTail();
                    AddHead(newHeadPos);
                }
                else if (boxHit == GridValue.Snake || boxHit == GridValue.Box)
                {
                    SoundEffect.PlayGameOverSound();
                    GameOver = true;
                    SaveHighScore();
                }
                else if (boxHit == GridValue.Goal)
                {
                    SoundEffect.PlayBoxSound();
                    DeleteObject(newHeadPos);
                    DeleteObject(newBoxPos);
                    RemoveTail();
                    AddFood(newBoxPos.Row, newBoxPos.Column);
                    AddHead(newHeadPos);
                }
                else
                {
                    DeleteObject(newHeadPos);
                    RemoveTail();
                    AddHead(newHeadPos);
                    MoveBox(newBoxPos);
                }
            }
        }
    }
}
