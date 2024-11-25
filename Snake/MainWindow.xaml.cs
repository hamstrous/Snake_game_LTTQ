using System.Text;
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
    public partial class MainWindow : Window
    {
        private readonly Dictionary<GridValue, ImageSource> gridValtoImage = new()
        {
            { GridValue.Empty, Images.Empty },
            { GridValue.Snake, Images.Body },
            { GridValue.Food, Images.Food },
            { GridValue.Box, Images.Box },
            { GridValue.Goal, Images.Goal },
            { GridValue.Wall, Images.Wall },
            { GridValue.DirectionPad, Images.DirectionPad }
        };

        private readonly Dictionary<Directions, int> dirToRotation = new()
        {
            {Directions.Up, 0 },
            {Directions.Right, 90},
            {Directions.Down, 180 },
            {Directions.Left, 270 }
        };

        private readonly int rows = 17, cols = 15;
        private readonly Image[,] gridImages;   
        private GameState gameState;
        private bool gameRunning;
        private GameInit GameInit { get; set; }
        private GameState Mode { get; set; }

        public void RefreshMode()
        {
            Mode = GameInit.GameMode switch
            {
                GameMode.Normal => new NormalModeState(rows, cols),
                GameMode.Box => new BoxModeState(rows, cols),
                GameMode.Wall => new WallModeState(rows, cols),
                GameMode.Direction => new DirectionModeState(rows, cols),
                GameMode.Reverse => new ReverseModeState(rows, cols),
                _ => new NormalModeState(rows, cols)
            };
            gameState = Mode;
        }

        public MainWindow()
        {
            InitializeComponent();
            GameInit = new GameInit(GameSize.Medium, GameSpeed.Medium, GameBackgroundColor.Dark, SnakeColor.Green, GameMode.Reverse);
            switch(GameInit.GameSize)
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
            RefreshMode();
            gridImages = SetupGrid();
        }

        private async Task RunGame()
        {
            Draw();
            await ShowCountDown();
            Overlay.Visibility = Visibility.Hidden;
            await GameLoop();
            await ShowGameOver();
            RefreshMode();
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Overlay.Visibility == Visibility.Visible)
            {
                e.Handled = true;
            }

            if (!gameRunning)
            {
                gameRunning = true;
                await RunGame();
                gameRunning = false; 
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           if (gameState.GameOver)
            {
                return;
            }

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
            }
        }

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
                await Task.Delay(delay);
                gameState.Move();
                Draw();
            }
        }


        private Image[,] SetupGrid() 
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;
            GameGrid.Width = GameGrid.Height * (cols / (double)rows);

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
                }
            }
            
            return images;
        }

        private void Draw()
        {
            DrawGrid();
            DrawSnakeHead();
            ScoreText.Text = $"SCORE { gameState.Score }";
            HighScoreText.Text = $"HIGHSCORE { gameState.HighScore }";
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

        private async Task DrawDeadSnake()
        {
            List<Positions> positions = new List<Positions>(gameState.SnakePositions());

            for (int i = 0; i < positions.Count; i++)
            {
                Positions pos = positions[i];
                ImageSource source = (i == 0) ? Images.DeadHead : Images.DeadBody;
                gridImages[pos.Row, pos.Column].Source = source;
                await Task.Delay(50);
            }
        }
        private async Task ShowCountDown()
        {
            for (int i = 3; i >= 1; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(500);
            }
        }

        private async Task ShowGameOver()
        {
            await DrawDeadSnake();
            await Task.Delay(500);
            Overlay.Visibility = Visibility.Visible;
            OverlayText.Text = "Ấn để bắt đầu!!";
        }
    }
}