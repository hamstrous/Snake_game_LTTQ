using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum GameSize
    {
        Small,
        Medium,
        Large
    }

    public enum GameSpeed
    {
        Slow,
        Medium,
        Fast
    }

    public enum BackgroundColor
    {
        Light,
        Dark
    }

    public enum SnakeColor
    {
        Green,
        Red,
        Blue,
        Yellow
    }

    public enum FoodColor
    {
        Green,
        Red,
        Blue,
        Yellow,
        Orange,
        Purple
    }

    public enum FoodAmount
    {
        One,
        Three,
        Five
    }

    public enum GameMode
    {
        Classic,
        Box,
        Wall,
        Direction,
        Reverse,
        Random
    }
    public class GameInit
    {
        public GameSize GameSize;
        public GameSpeed GameSpeed;
        public BackgroundColor GameBackgroundColor;
        public SnakeColor SnakeColor;
        public GameMode GameMode;
        public FoodColor FoodColor;
        public FoodAmount FoodAmount;
        public GameInit()
        {
            GameSize = GameSize.Medium;
            GameSpeed = GameSpeed.Medium;
            GameBackgroundColor = BackgroundColor.Light;
            SnakeColor = SnakeColor.Green;
            GameMode = GameMode.Classic;
        }
        public GameInit(GameSize gameSize, GameSpeed gameSpeed, BackgroundColor gameBackgroundColor, SnakeColor snakeColor, GameMode gameMode, FoodAmount foodAmount)
        {
            GameSize = gameSize;
            GameSpeed = gameSpeed;
            GameBackgroundColor = gameBackgroundColor;
            SnakeColor = snakeColor;
            GameMode = gameMode;
            FoodAmount = foodAmount;
        }
    }
}
