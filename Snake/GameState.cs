using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum GameMode
    {
        Normal,
        Box
    }
   public class GameState
    {
        public int Rows { get; protected set; }
        public int Cols { get; protected set; }

        public GridValue[,] Grid {  get; protected set; }

        public Directions Dir { get; protected set; }
        public int Score { get; protected set; }
        
        public int HighScore { get; protected set; }
        public bool GameOver { get; protected set; }

        public GameMode Mode { get; protected set; }

        protected readonly LinkedList<Directions> dirChanges = new LinkedList<Directions>();
        protected LinkedList<Positions> snakePositions = new LinkedList<Positions>();
        protected readonly Random random = new Random();

        public GameState(int rows , int cols)
        {
            
        }

        protected void AddSnake()
        {
            int r = Rows / 2;
            
            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePositions.AddFirst(new  Positions(r, c));
            }
        }

        protected virtual IEnumerable<Positions> EmptyPositions()
        {
            for (int r = 0;  r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r , c] == GridValue.Empty)
                    {
                        yield return new Positions(r, c);
                    }
                }
            }
        }

        protected void AddObject(GridValue ob, int x = -1, int y = -1)
        {
            List<Positions> empty = new List<Positions>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = (x == -1) ? empty[random.Next(empty.Count)] : new Positions(x, y);
            Grid[pos.Row, pos.Column] = ob;
        }
        protected void AddFood(int x = -1 ,int y = -1)
        {
            List<Positions> empty = new List<Positions>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = (x == -1) ? empty[random.Next(empty.Count)]:new Positions(x,y);
            Grid[pos.Row, pos.Column] = GridValue.Food;
        }

        public Positions HeadPosition()
        {
            return snakePositions.First.Value;
        }

        public Positions TailPosition()
        {
            return snakePositions.Last.Value;
        }

        public IEnumerable<Positions> SnakePositions()
        {
            return snakePositions;
        }

        protected void AddHead(Positions pos)
        {
            snakePositions.AddFirst(pos);
            Grid[pos.Row, pos.Column] = GridValue.Snake;
        }

        protected void RemoveTail()
        {
            Positions tail = snakePositions.Last.Value;
            Grid[tail.Row, tail.Column] = GridValue.Empty;
            snakePositions.RemoveLast();
        }

        protected Directions GetLastDirection()
        {
            if (dirChanges.Count == 0)
            {
                return Dir;
            }

            return dirChanges.Last.Value;
        }

        protected bool CanChangeDirection(Directions newDir)
        {
            if (dirChanges.Count == 2)
            {
                return false;
            }

            Directions lastDir = GetLastDirection();
            return newDir != lastDir && newDir != lastDir.Opposite();
        }

        public void ChangeDirection(Directions dir)
        {
            if (CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);
            }
        }

        protected bool OutsideGrid(Positions pos)
        {
            return pos.Row < 0 || pos.Column < 0 || pos.Row >= Rows || pos.Column >= Cols;
        }

        protected GridValue WillHit(Positions newHeadPos)
        {
            if (OutsideGrid(newHeadPos))
            {
                return GridValue.Outside;
            }

            if (newHeadPos == TailPosition()) 
            {
                return GridValue.Empty;
            }

            return Grid[newHeadPos.Row, newHeadPos.Column];
        }

        public virtual void Move()
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
            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (hit == GridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
                AddFood();
            }
        }

        public void SaveHighScore()
        {
            File.WriteAllText("highscore.txt", HighScore.ToString());
        }

        public void LoadHighScore()
        {
            HighScore = 0;
            if (File.Exists("highscore.txt"))
            {
                    string savedScore = File.ReadAllText("highscore.txt");
                    HighScore = int.Parse(savedScore);
            }

        }
    }
}
