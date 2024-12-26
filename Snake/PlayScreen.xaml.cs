using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for PlayScreen.xaml
    /// </summary>
    public partial class PlayScreen : UserControl
    {

        private Dictionary<GridValue, System.Windows.Media.ImageSource> gridValtoImage;

        private Dictionary<Directions, int> dirToRotation = new()
        {
            {Directions.Up, 0 },
            {Directions.Right, 90},
            {Directions.Down, 180 },
            {Directions.Left, 270 }
        };

        private int rows = 17, cols = 15;
        private Image[,] gridImages;
        private GameState gameState;
        private bool gameRunning;
        private GameInit GameInit { get; set; }
        private GameState Mode { get; set; }

        public Image HeadImage { get; set; }
        public Image TailImage { get; set; }

        public double cellSize => Math.Min(GameGrid.Width / GameGrid.Columns,
                         GameGrid.Height / GameGrid.Rows);

        public void InitMode()
        {
            int foods = 1;
            switch (GameInit.FoodAmount)
            {
                case FoodAmount.One:
                    foods = 1;
                    break;
                case FoodAmount.Three:
                    foods = 3;
                    break;
                case FoodAmount.Five:
                    foods = 5;
                    break;
            }

            Mode = GameInit.GameMode switch
            {
                GameMode.Classic => new ClassicModeState(rows, cols, foods),
                GameMode.Box => new BoxModeState(rows, cols, foods),
                GameMode.Wall => new WallModeState(rows, cols, foods),
                GameMode.Direction => new DirectionModeState(rows, cols, foods),
                GameMode.Reverse => new ReverseModeState(rows, cols, foods),
                _ => new ClassicModeState(rows, cols, foods)
            };
            gameState = Mode;
            InitSnakeSmoothMovement();
        }

        public void InitFoodColor()
        {
            switch (GameInit.FoodType)
            {
                case FoodType.Apple:
                    Images.Food = Images.Apple;
                    break;
                case FoodType.Grape:
                    Images.Food = Images.Grape;
                    break;
                case FoodType.Banana:
                    Images.Food = Images.Banana;
                    break;
                case FoodType.Peach:
                    Images.Food = Images.Peach;
                    break;
                case FoodType.Radish:
                    Images.Food = Images.Radish;
                    break;
            }
        }

        public PlayScreen(GameInit init)
        {
            InitializeComponent();
            GameInit = init;
            //GameInit = new GameInit(GameSize.Medium, GameSpeed.Medium, GameBackgroundColor.Dark, SnakeColor.Green, GameMode.Reverse);
            switch (GameInit.GameSize)
            {
                case GameSize.Small:
                    rows = 13;
                    cols = 11;
                    break;
                case GameSize.Medium:
                    rows = 17;
                    cols = 15;
                    break;
                case GameSize.Large:
                    rows = 21;
                    cols = 19;
                    break;
            }
            Images.AssignImages(GameInit);
            gridValtoImage = new()
            {
                { GridValue.Empty, Images.Empty },
                { GridValue.Snake, Images.Body },
                { GridValue.Food, Images.Food },
                { GridValue.Box, Images.Box },
                { GridValue.Goal, Images.Goal },
                { GridValue.Wall, Images.Wall },
                { GridValue.DirectionPad, Images.DirectionPad }
            };
            gridImages = SetupGrid();
            HeadImage = new Image();
            TailImage = new Image();
            GameGrid.Focus();
            Loaded += PlayScreen_Loaded;
            StartGame();
        }

        private void StartGame()
        { 
            RunGame();
        }

        private async Task SaveScoreCurrent()
        {
            //SignIn.currentUserName = "testuser01";
            int score = gameState.Score;
            int mode = (int)GameInit.GameMode;


            await SaveScore.SavePlayerScore(SignIn.currentUserName, score, mode);
        }

        private async Task RunGame()
        {
            InitMode();
            Draw();
            await CountDown();
            gameRunning = true;
            await GameLoop();
            gameRunning = false;
            SaveScoreCurrent();
            await ShowGameOver();

        }

        private async Task CountDown()
        {
            OverlayText.Visibility = Visibility.Visible;
            for (int i = 3; i >= 1; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(750);
            }
            OverlayText.Visibility = Visibility.Hidden;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }
            if(gameRunning)
                switch (e.Key)
                {
                    case Key.Left:
                        gameState.ChangeDirection(Directions.Left);
                        break;
                    case Key.Right:
                        gameState.ChangeDirection(Directions.Right);
                        break;
                    case Key.Up:
                        gameState.ChangeDirection(Directions.Up);
                        break;
                    case Key.Down:
                        gameState.ChangeDirection(Directions.Down);
                        break;
                    case Key.Escape:
                        if (GamePause.Pause) 
                        {
                            GamePause.Visibility = Visibility.Hidden;
                            GamePause.Pause = false;
                        }
                        else
                        {
                            GamePause.Visibility = Visibility.Visible;
                            GamePause.Pause = true;
                        }
                        break;
                }
        }
        bool gameLoop = false;
        private async Task GameLoop()
        {   

            int delay = GameInit.GameSpeed switch
            {
                GameSpeed.Slow => 200,
                GameSpeed.Medium => 100,
                GameSpeed.Fast => 50,
                _ => 100
            };
            while (!gameState.GameOver)
            {
                if(GamePause.Pause)
                {
                    await Task.Delay(100);
                    continue;
                }
                Mode.Ate = true;
                gameState.Move();
                if (!gameState.GameOver && Mode.Moving)
                {
                    Positions boxPos = Mode.NeedToMoveBox();
                    if (boxPos != null) ImageSmoothMovement("Box.png", delay, boxPos);
                    await SnakeSmoothMovement(delay);
                }
                else if (!Mode.Moving)
                {
                    Canva.Children.Clear();
                    HeadImage = new Image();
                    TailImage = new Image();
                    InitSnakeSmoothMovement();
                    await Task.Delay(500);
                }
                else if (gameState.GameOver)
                {
                    Canva.Children.Clear();
                    HeadImage = new Image();
                    TailImage = new Image();
                    break;
                }
                Draw();
            }
        }

        public Point GetCellPosition(int row, int col)
        {
            double cellWidth = GameGrid.Width / GameGrid.Columns;
            double cellHeight = GameGrid.Height / GameGrid.Rows;



            // Calculate position within the UniformGrid
            double x = col * cellWidth;
            double y = row * cellHeight;

            // Transform to screen coordinates
            //Point gridPosition = GameGrid.TranslatePoint(new , null);
            //MessageBox.Show(gridPosition.ToString());

            return new Point(x, y);
        }

        public void InitSnakeSmoothMovement()
        {
            HeadImage = new Image
            {
                Source = Images.Head,
                RenderTransformOrigin = new Point(0.5, 0.5)
            };
            HeadImage.RenderTransform = new RotateTransform(dirToRotation[Mode.Grid[Mode.HeadPosition().Row, Mode.HeadPosition().Column].First.Value.Second]);

            TailImage = new Image
            {
                Source = Images.Body,
                RenderTransformOrigin = new Point(0.5, 0.5)
            };
            HeadImage.Width = cellSize;
            HeadImage.Height = cellSize;
            TailImage.Width = cellSize;
            TailImage.Height = cellSize;
            Point HeadPos = GetCellPosition(Mode.HeadPosition().Row, Mode.HeadPosition().Column);
            Point TailPos = GetCellPosition(Mode.TailPosition().Row, Mode.TailPosition().Column);

            Canva.Children.Add(HeadImage);
            Canva.Children.Add(TailImage);

            Canvas.SetLeft(HeadImage, HeadPos.X); // X position
            Canvas.SetTop(HeadImage, HeadPos.Y);  // Y position
            Canvas.SetLeft(TailImage, TailPos.X); // X position
            Canvas.SetTop(TailImage, TailPos.Y);  // Y position
        }

        private async Task SnakeSmoothMovement(int delay)
        {
            int steps = delay / 10;
            double increment = cellSize / steps;
            for (int i = 0; i < steps; i++)
            {
                await Task.Delay(10);
                Dispatcher.Invoke(() =>
                {
                    Directions dir = Mode.Grid[Mode.HeadPosition().Row, Mode.HeadPosition().Column].First.Value.Second;
                    if (dir == Directions.Left) Canvas.SetLeft(HeadImage, Canvas.GetLeft(HeadImage) - increment);
                    else if (dir == Directions.Right) Canvas.SetLeft(HeadImage, Canvas.GetLeft(HeadImage) + increment);
                    else if (dir == Directions.Up) Canvas.SetTop(HeadImage, Canvas.GetTop(HeadImage) - increment);
                    else if (dir == Directions.Down) Canvas.SetTop(HeadImage, Canvas.GetTop(HeadImage) + increment);
                    HeadImage.RenderTransform = new RotateTransform(dirToRotation[dir]);
                    if (!Mode.Ate)
                    {
                        dir = Mode.Grid[Mode.TailPosition().Row, Mode.TailPosition().Column].First.Value.Second;
                        if (dir == Directions.Left) Canvas.SetLeft(TailImage, Canvas.GetLeft(TailImage) - increment);
                        else if (dir == Directions.Right) Canvas.SetLeft(TailImage, Canvas.GetLeft(TailImage) + increment);
                        else if (dir == Directions.Up) Canvas.SetTop(TailImage, Canvas.GetTop(TailImage) - increment);
                        else if (dir == Directions.Down) Canvas.SetTop(TailImage, Canvas.GetTop(TailImage) + increment);
                        TailImage.RenderTransform = new RotateTransform(dirToRotation[dir]);
                    }

                });

            }
        }

        private async Task ImageSmoothMovement(string url, int delay, Positions pos)
        {
            Image image = new Image
            {
                Source = Images.LoadImage(url),
                RenderTransformOrigin = new Point(0.5, 0.5)
            };

            image.Width = cellSize;
            image.Height = cellSize;
            Point point = GetCellPosition((int)pos.Row, (int)pos.Column);

            Canva.Children.Add(image);
            Canvas.SetLeft(image, point.X); // X position
            Canvas.SetTop(image, point.Y);  // Y position

            int steps = delay / 10;
            double increment = cellSize / steps;
            for (int i = 0; i < steps; i++)
            {
                await Task.Delay(10);
                Dispatcher.Invoke(() =>
                {
                    Directions dir = Mode.Grid[pos.Row, pos.Column].First.Value.Second;
                    if (dir == Directions.Left) Canvas.SetLeft(image, Canvas.GetLeft(image) - increment);
                    else if (dir == Directions.Right) Canvas.SetLeft(image, Canvas.GetLeft(image) + increment);
                    else if (dir == Directions.Up) Canvas.SetTop(image, Canvas.GetTop(image) - increment);
                    else if (dir == Directions.Down) Canvas.SetTop(image, Canvas.GetTop(image) + increment);
                    image.RenderTransform = new RotateTransform(dirToRotation[dir]);

                });

            }
            Canva.Children.Remove(image);
            image = new Image();

        }

        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            BackGroundGrid.Rows = rows;
            GameGrid.Columns = cols;
            BackGroundGrid.Columns = cols;
            GameGrid.Width = GameGrid.Height * (cols / (double)rows);
            BackGroundGrid.Width = BackGroundGrid.Height * (cols / (double)rows);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty,
                        RenderTransformOrigin = new Point(0.5, 0.5)
                    };
                    images[r, c] = image;
                    GameGrid.Children.Add(image);

                    Image bgImage = new Image
                    {
                        RenderTransformOrigin = new Point(0.5, 0.5)
                    };
                    if ((r + c) % 2 == 0) bgImage.Source = Images.Bg1;
                    else bgImage.Source = Images.Bg2;
                    BackGroundGrid.Children.Add(bgImage);
                }
            }
            return images;
        }

        private void Draw()
        {
            DrawGrid();
            //DrawSnakeHead();
            DrawSnakeTail();
            ScoreText.Text = $"SCORE {gameState.Score}";
            HighScoreText.Text = $"HIGHSCORE {gameState.HighScore}";
        }

        private void DrawGrid()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    GridValue gridVal = gameState.Grid[r, c].First.Value.First;
                    int rotation = dirToRotation[gameState.Grid[r, c].First.Value.Second];

                    gridImages[r, c].Source = gridValtoImage[gridVal];
                    gridImages[r, c].RenderTransform = new RotateTransform(rotation);
                }
            }
        }

        private void DrawSnakeHead()
        {
            Positions headPos = gameState.HeadPosition();
            Image image = gridImages[headPos.Row, headPos.Column];
            image.Source = Images.Head;

        }

        private void DrawSnakeTail()
        {
            Positions tailPos = gameState.TailPosition();
            Image image = gridImages[tailPos.Row, tailPos.Column];
            image.Source = Images.Empty;

        }

        private async Task DrawDeadSnake()
        {
            List<Positions> positions = new List<Positions>(gameState.SnakePositions());

            for (int i = 0; i < positions.Count; i++)
            {
                Positions pos = positions[i];
                ImageSource source = (i == 0) ? Images.DeadHead : Images.DeadBody;
                gridImages[pos.Row, pos.Column].Source = source;
                int rotation = dirToRotation[gameState.Grid[pos.Row, pos.Column].First.Value.Second];
                gridImages[pos.Row, pos.Column].RenderTransform = new RotateTransform(rotation);
                await Task.Delay(50);
            }
        }

        public event EventHandler CloseGame;

        private async Task ShowGameOver()
        {
            SoundEffect.PlayGameOverSound();
            await DrawDeadSnake();
            bool retry = await GameOver.ShowDialogAsync();
            if (!retry)
            {
                OnCloseGame();
                return;
            }
            HeadImage = null;
            TailImage = null;
            StartGame();
        }

        protected virtual void OnCloseGame()
        {
            CloseGame?.Invoke(this, EventArgs.Empty);
        }

        private void PlayScreen_Loaded(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                AdjustToWindowSize(parentWindow);
                parentWindow.SizeChanged += ParentWindow_SizeChanged;
            }
        }

        private void ParentWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustToWindowSize(sender as Window);
        }

        private void AdjustToWindowSize(Window window)
        {
            if (window != null)
            {
                this.Width = window.ActualWidth;
                this.Height = window.ActualHeight;
            }
        }
    }
}