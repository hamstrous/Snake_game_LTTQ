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

    public enum SnakeColor
    {
        Blue,
        Brown,
        Red,
        Purple,
        Pink,
        Cyan
    }

    public enum FoodType
    {
        Apple,
        Grape,
        Banana,
        Peach,
        Radish,
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
        public SnakeColor SnakeColor;
        public GameMode GameMode;
        public FoodType FoodType;
        public FoodAmount FoodAmount;
        public GameInit()
        {
            GameSize = GameSize.Medium;
            GameSpeed = GameSpeed.Medium;
            SnakeColor = SnakeColor.Blue;
            GameMode = GameMode.Classic;
            FoodType = FoodType.Apple;
            FoodAmount = FoodAmount.One;
        }
        public GameInit(GameSize gameSize, GameSpeed gameSpeed, SnakeColor snakeColor, GameMode gameMode, FoodAmount foodAmount)
        {
            GameSize = gameSize;
            GameSpeed = gameSpeed;
            SnakeColor = snakeColor;
            GameMode = gameMode;
            FoodAmount = foodAmount;
        }
    }
}
