using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Util;

namespace BreakoutStep1
{
    internal class GameHandleBlock : DrawableGameComponent
    {
        Ball balls;

        public List<MonogameBlock> Blocks { get; private set; }
        List<MonogameBlock> BreakBlock;

        public GameHandleBlock(Game game, Ball ball) : base(game)
        {
            this.Blocks = new List<MonogameBlock>();
            this.BreakBlock = new List<MonogameBlock>();
            this.balls = ball;
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        bool reflected;

        public override void Update(GameTime gameTime)
        {
            this.reflected = false;
            BlockCollideWithBall(gameTime);
            UpdateBlocks(gameTime);
            RemoveBlocks();
        }

        private void UpdateBlocks(GameTime gameTime)
        {
            foreach (var block in Blocks)
            {
                block.Update(gameTime);
            }
        }

        private void RemoveBlocks()
        {
            foreach(var block in BreakBlock) 
            { 
                Blocks.Remove(block);
            }
            BreakBlock.Clear();
        }

        private void BlockCollideWithBall(GameTime gameTime)
        {
            foreach(MonogameBlock ball in Blocks)
            {
                if (ball.Enabled)
                {
                    ball.Update(gameTime);

                    if(ball.Intersects(balls))
                    {
                        ball.HitByBall(balls);
                        balls.Direction.Y *= -2;

                        if(ball.BlockState == BlockState.Broken) BreakBlock.Add(ball);
                        
                    }
                }
            }
        }
    }
}
