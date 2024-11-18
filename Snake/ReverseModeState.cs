using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ReverseModeState : GameState
    {
        int eaten = 0;
        public ReverseModeState(int rows, int cols) : base(rows, cols)
        {
            AddSnake();
            AddFood();
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
                Grid[HeadPosition().Row, HeadPosition().Column].First.Value.Second = Dir;
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
            if(eaten > 0)
            {
                eaten--;
                return;
            }
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
            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (hit == GridValue.Food)
            {
                Directions nDir = TailDirection();
                DeleteObject(newHeadPos);
                Dir = nDir;
                AddHead(newHeadPos);
                SwapSnake();
                
                eaten = 3;
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
