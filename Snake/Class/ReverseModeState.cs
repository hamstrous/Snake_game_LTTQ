using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ReverseModeState : GameState
    {
        public ReverseModeState(int rows, int cols, int foods) : base(rows, cols, foods)
        {
            AddSnake();
            for(int i=1;i<=FoodCount;i++) AddFood();
        }

        public void SwapSnake()
        {
            if (snakePositions.Count > 1)
            {
                LinkedList<Positions> reversedList = new LinkedList<Positions>();
                LinkedListNode<Positions> currentNode = snakePositions.First;
                while (currentNode != null)
                {
                    reversedList.AddFirst(currentNode.Value);
                    currentNode = currentNode.Next;
                }
                snakePositions = reversedList;
                
                currentNode = snakePositions.First;
                while (currentNode != null)
                {
                    Positions pos = currentNode.Value;
                    LinkedListNode<Positions> nextNode = currentNode.Next;
                    if (nextNode != null)
                    {
                        Positions nextPos = currentNode.Next.Value;
                        Grid[pos.Row, pos.Column].First.Value.Second = Grid[nextPos.Row, nextPos.Column].First.Value.Second.Opposite();
                    }
                    else
                    {
                        Grid[pos.Row, pos.Column].First.Value.Second = Grid[pos.Row, pos.Column].First.Value.Second.Opposite();

                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        public Directions TailDirection()
        {
            Positions preTail = snakePositions.Last.Previous.Value;
            Positions tail = snakePositions.Last.Value;

            if (preTail.Row == tail.Row)
            {
                if (preTail.Column < tail.Column)
                {
                    return Directions.Right;
                }
                else
                {
                    return Directions.Left;
                }
            }
            else
            {
                if (preTail.Row < tail.Row)
                {
                    return Directions.Down;
                }
                else
                {
                    return Directions.Up;
                }
            }
        }

        public override void Move()
        {
            Moving = true;
            if (dirChanges.Count > 0)
            {
                SoundEffect.PlayMoveSound();
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();
            }

            Positions newHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newHeadPos);

            if (hit == GridValue.Outside || hit == GridValue.Snake)
            {
                SoundEffect.PlayGameOverSound();
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
                SoundEffect.PlayEatSound();
                Directions nDir = TailDirection();
                DeleteObject(newHeadPos);
                AddHead(newHeadPos);
                SwapSnake();
                Dir = nDir;
                Moving = false;
                Score++;
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
                AddFood();
            }
        }
    }
}
