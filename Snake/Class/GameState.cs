using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake
{
    public class GameState
    {
        public bool Moving = true;
        public int Rows { get; protected set; }
        public int Cols { get; protected set; }

        public bool blockDirChange = false;
        public LinkedList<Pair<GridValue, Directions>>[,] Grid { get; protected set; }

        public Directions Dir { get; protected set; }
        public int Score { get; protected set; }
        public int FoodCount { get; set; }
        public int HighScore { get; protected set; }
        public List<int> HighScores { get; protected set; } = new List<int> { 0, 0, 0, 0, 0 };

        public bool GameOver { get; protected set; }
        public bool Ate { get; set; }
        public static int nowMode { get; set; }
        public GameMode Mode { get; protected set; }

        protected readonly LinkedList<Directions> dirChanges = new LinkedList<Directions>();
        protected LinkedList<Positions> snakePositions = new LinkedList<Positions>();
        protected readonly Random random = new Random();

        public GameState(int rows, int cols, int foods)
        {
            FoodCount = foods;
            Grid = new LinkedList<Pair<GridValue, Directions>>[rows, cols];
            Dir = Directions.Right;
            Rows = rows;
            Cols = cols;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Grid[i, j] = new LinkedList<Pair<GridValue, Directions>>();
                    Grid[i, j].AddFirst((GridValue.Empty, Directions.Up));
                }
            }
            LoadHighScore();
        }

        protected void AddSnake()
        {
            int r = Rows / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c].AddFirst((GridValue.Snake, Directions.Right));
                snakePositions.AddFirst(new Positions(r, c));
            }

        }

        protected virtual IEnumerable<Positions> EmptyPositions()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c].First.Value == GridValue.Empty)
                    {
                        yield return new Positions(r, c);
                    }
                }
            }
        }

        // Delete upper object
        protected void DeleteObject(Positions pos)
        {
            Grid[pos.Row, pos.Column].RemoveFirst();
        }

        protected void AddObject(GridValue ob, int x = -1, int y = -1)
        {
            List<Positions> empty = new List<Positions>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = (x == -1) ? empty[random.Next(empty.Count)] : new Positions(x, y);
            Grid[pos.Row, pos.Column].AddFirst((ob, Directions.Up));
        }
        protected void AddFood(int x = -1, int y = -1)
        {
            List<Positions> empty = new List<Positions>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Positions pos = (x == -1) ? empty[random.Next(empty.Count)] : new Positions(x, y);
            Grid[pos.Row, pos.Column].AddFirst((GridValue.Food, Directions.Up));
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
            Grid[pos.Row, pos.Column].AddFirst((GridValue.Snake, Dir));
        }

        protected void RemoveTail()
        {
            Ate = false;
            Positions tail = snakePositions.Last.Value;
            DeleteObject(tail);
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
            if (dirChanges.Count == 2 || blockDirChange)
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

            return Grid[newHeadPos.Row, newHeadPos.Column].First.Value.First;
        }

        public void PlayEatSound()
        {
            SoundEffect.PlayEatSound();
        }

        public virtual Positions NeedToMoveBox()
        {
            return null;
        }

        public virtual void Move()
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
                PlayEatSound();
                DeleteObject(newHeadPos);
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
            Grid[HeadPosition().Row, HeadPosition().Column].First.Value = (GridValue.Snake, Dir);

            int currentMode = nowMode;

            if (currentMode >= 0 && currentMode <= 4 && HighScores[currentMode] < HighScore)
            {
                HighScores[currentMode] = HighScore;
            }

            string Scores = string.Join(" ", HighScores.Select(score => score.ToString()).ToArray());

            File.WriteAllText("highscore.txt", Scores);

        }

        public void LoadHighScore()
        {
            HighScores.Clear();

            if (File.Exists("highscore.txt"))
            {
                string savedScores = File.ReadAllText("highscore.txt");
                string[] scoreStrings = savedScores.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var scoreString in scoreStrings)
                {
                    if (int.TryParse(scoreString, out int score))
                    {
                        HighScores.Add(score);
                    }
                }
            }

            HighScore = 0;
            int currentMode = nowMode;

            if ( currentMode >= 0 && currentMode <= 4)
            {
                HighScore = HighScores[currentMode];
            }

        }
    }
}