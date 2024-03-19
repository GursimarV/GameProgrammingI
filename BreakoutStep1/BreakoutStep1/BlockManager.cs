using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;

namespace BreakoutStep1
{
    internal class BlockManager : DrawableGameComponent
    {
        Ball balls;

        public List<MonogameBlock> Blocks { get; private set; }
        List<MonogameBlock> BreakBlock;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        string winloseText;
        public bool isGameOver;


        public BlockManager(Game game, Ball ball) : base(game)
        {
            this.Blocks = new List<MonogameBlock>();
            this.BreakBlock = new List<MonogameBlock>();
            this.balls = ball;
            ScoreManager.Level = 1;
            isGameOver = false;
        }

        public override void Initialize()
        {
            LoadLevel();
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            spriteFont = Game.Content.Load<SpriteFont>("Arial");
            base.Initialize();
        }

        /// <summary>
        /// Replacable Method to Load a Level by filling the Blocks List with Blocks
        /// </summary>
        protected virtual void LoadLevel()
        {
            CreateBlockArrayByWidthAndHeight(24, 2, 1);
        }

        /// <summary>
        /// Simple Level lays out multiple levels of blocks
        /// </summary>
        /// <param name="width">Number of blocks wide</param>
        /// <param name="height">Number of blocks high</param>
        /// <param name="margin">space between blocks</param>
        private void CreateBlockArrayByWidthAndHeight(int width, int height, int margin)
        {
            MonogameBlock b;
            //Create Block Array based on with and hieght
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    b = new MonogameBlock(this.Game);
                    b.Initialize();
                    b.Location = new Vector2(5 + (w * b.SpriteTexture.Width + (w * margin)), 50 + (h * b.SpriteTexture.Height + (h * margin)));
                    Blocks.Add(b);
                }
            }
        }

        bool reflected; //the ball should only reflect once even if it hits two bricks

        public override void Update(GameTime gameTime)
        {
            this.reflected = false;
            BlockCollideWithBall(gameTime);
            UpdateBlocks(gameTime);
            RemoveBlocks();

            if (!isGameOver)
                IsWinOrLose(gameTime);

            base.Update(gameTime);
        }

        private void UpdateBlocks(GameTime gameTime)
        {
            foreach (var block in Blocks)
            {
                block.Update(gameTime);
            }
        }

        /// <summary>
        /// Removes disabled blocks from list
        /// </summary>
        private void RemoveBlocks()
        {
            foreach(var block in BreakBlock) 
            { 
                Blocks.Remove(block);
                ScoreManager.Score++;
            }
            BreakBlock.Clear();
        }

        private void BlockCollideWithBall(GameTime gameTime)
        {
            foreach(MonogameBlock block in Blocks)
            {
                if (block.Enabled)
                {
                    block.Update(gameTime);

                    if(block.Intersects(balls))
                    {
                        block.HitByBall(balls);
                        if (block.BlockState == BlockState.Broken)
                            BreakBlock.Add(block);
                        if(!reflected) //only reflect once
                        {
                            balls.Reflect(block);
                            this.reflected = true;
                        }
                        
                    }
                }
            }
        }

        private void IsWinOrLose(GameTime gameTime)
        {
            if(!Blocks.Any())
            {
                WinCondition(gameTime);
            }

            else if(ScoreManager.Lives <= 0)
            {
                LoseCondition(gameTime);
            }

            else
            {
                isGameOver = false;
            }
        }

        private void WinCondition(GameTime gameTime)
        {
            InputHandler input = (InputHandler)this.Game.Services.GetService(typeof(IInputHandler));
            winloseText = "You Win!";
            isGameOver = true;
            if (input.KeyboardState.IsKeyDown(Keys.F))
            {
                ScoreManager.Level++;
                ScoreManager.Lives = 3;
                LoadLevel();
                isGameOver = false;
                balls.resetBall(gameTime);
            }
        }

        private void LoseCondition(GameTime gameTime)
        {
            ScoreManager.Lives = 0;
            InputHandler input = (InputHandler)this.Game.Services.GetService(typeof(IInputHandler));
            winloseText = "You Lost!!!";
            isGameOver = true;
            if (input.KeyboardState.IsKeyDown(Keys.F))
            {
                ScoreManager.Score = 0;
                ScoreManager.Level = 1;
                ScoreManager.Lives = 5;
                LoadLevel();
                isGameOver = false;
                balls.resetBall(gameTime);
            }
        }


        public override void Draw(GameTime gameTime)
        {
            foreach (var block in this.Blocks)
            {
                if(block.Visible)
                    block.Draw(gameTime);
            }

            spriteBatch.Begin();

            if (isGameOver)
            {
                spriteBatch.DrawString(spriteFont, winloseText, new Vector2(Game.GraphicsDevice.Viewport.Width / 1.13f, Game.GraphicsDevice.Viewport.Height / 1.155f), Color.Red);
                spriteBatch.DrawString(spriteFont, "Press F to continue", new Vector2(Game.GraphicsDevice.Viewport.Width / 1.27f, Game.GraphicsDevice.Viewport.Height / 1.11f), Color.White);
            }
            spriteBatch.DrawString(spriteFont, "Press G to slingshot the ball!", new Vector2(Game.GraphicsDevice.Viewport.Width / 80, Game.GraphicsDevice.Viewport.Height / 1.06f), Color.Magenta);
            spriteBatch.DrawString(spriteFont, "Press Space to slow time!", new Vector2(Game.GraphicsDevice.Viewport.Width / 1.4f, Game.GraphicsDevice.Viewport.Height / 1.06f), Color.Yellow);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
