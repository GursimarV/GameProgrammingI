using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneButtonGame
{
    internal class Timer : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont font;

        public float timerTime;
        float timerSpan;

        public Timer(Game game) : base(game)
        {
            timerSpan = timerTime = 10000;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("Font");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (timerTime >= 0) 
            {
                timerTime -= gameTime.ElapsedGameTime.Milliseconds;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Timer:", new Vector2(150, 50), Color.Blue);
            spriteBatch.DrawString(font, timerTime.ToString(), new Vector2(200, 50), Color.Blue);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
