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

    public enum GameBackgroundColor
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
        public GameBackgroundColor GameBackgroundColor;
        public SnakeColor SnakeColor;
        public GameMode GameMode;
        public GameInit()
        {
            GameSize = GameSize.Medium;
            GameSpeed = GameSpeed.Medium;
            GameBackgroundColor = GameBackgroundColor.Light;
            SnakeColor = SnakeColor.Green;
            GameMode = GameMode.Classic;
        }
        public GameInit(GameSize gameSize, GameSpeed gameSpeed, GameBackgroundColor gameBackgroundColor, SnakeColor snakeColor, GameMode gameMode)
        {
            GameSize = gameSize;
            GameSpeed = gameSpeed;
            GameBackgroundColor = gameBackgroundColor;
            SnakeColor = snakeColor;
            GameMode = gameMode;
        }
    }
}
