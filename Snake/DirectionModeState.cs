﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class DirectionModeState : GameState
    {
        public DirectionModeState(int rows, int cols, int foods) : base(rows, cols, foods)
        {
            AddSnake();
            for(int i=1;i<=FoodCount;i++) AddFood();
        }

        public void AddDirectionPad(Positions pos, Directions dir)
        {
            Grid[pos.Row, pos.Column].Last.Value = (GridValue.DirectionPad, dir);
            Grid[pos.Row, pos.Column].AddLast((GridValue.Empty, Directions.Up));
        }

        public override void Move()
        {
            blockDirChange = false;
            if (dirChanges.Count > 0)
            {
                SoundEffect.PlayMoveSound();
                Dir = dirChanges.First.Value;
                AddDirectionPad(HeadPosition(),Dir);
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
            else if (hit == GridValue.Empty || hit == GridValue.Goal)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if(hit == GridValue.DirectionPad)
            {
                Directions ForcedDir = Grid[newHeadPos.Row, newHeadPos.Column].First.Value.Second;
                if (Dir.Opposite() == ForcedDir)
                {
                    SoundEffect.PlayGameOverSound();
                    GameOver = true;
                    SaveHighScore();
                }
                else
                {
                    SoundEffect.PlayMoveSound();
                    DeleteObject(newHeadPos);
                    RemoveTail();
                    AddHead(newHeadPos);
                    Dir = ForcedDir;
                    dirChanges.Clear();
                    blockDirChange = true;
                }
            }
            else if (hit == GridValue.Food)
            {
                SoundEffect.PlayEatSound();
                DeleteObject(newHeadPos);
                AddHead(newHeadPos);
                AddFood();
                Score++;
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
            }
        }
    }
}
