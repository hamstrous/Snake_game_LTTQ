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
        private Dictionary<GridValue, ImageSource> gridValtoImage;

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
        }

        public void InitFoodColor()
        {switch (GameInit.FoodType)
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

        public MainWindow(GameInit init)
        {
            InitializeComponent();
            GameInit = init;
            //GameInit = new GameInit(GameSize.Medium, GameSpeed.Medium, GameBackgroundColor.Dark, SnakeColor.Green, GameMode.Reverse);
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

            InitMode();
            //InitFoodColor();
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
        }

        private async Task SaveScoreCurrent()
        {
            SignIn.currentUserName = "testuser01";
            
            Guid? userId = await SaveScore.GetUserIdAsync(SignIn.currentUserName);

            if (userId == null)
            {
                MessageBox.Show("Không tìm thấy người dùng.");
                return;
            }

            
            int score = gameState.Score;
            int mode = (int)GameInit.GameMode;

            
            await SaveScore.SavePlayerScore(userId.Value, score, mode);  
        }




        private async Task RunGame()
        {
            Draw();
            await ShowCountDown();
            await GameLoop();
            SaveScoreCurrent();
            await ShowGameOver();
            InitMode();
            
            //await Task.Delay(1000);
            //MainMenu mainMenu = new MainMenu();
            //mainMenu.Show();
            //this.Close();
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

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
                    if((r+c) % 2 == 0) bgImage.Source = Images.Bg1;
                    else bgImage.Source = Images.Bg2;
                    BackGroundGrid.Children.Add(bgImage);
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
                await Task.Delay(500);
            }
        }

        private async Task ShowGameOver()
        {
            SoundEffect.PlayGameOverSound();
            await DrawDeadSnake();
        }
    }
}