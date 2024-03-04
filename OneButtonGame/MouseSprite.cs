using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneButtonGame
{
    internal class MouseSprite : DrawableGameComponent
    {
        Vector2 mouseLoc;
        Texture2D mousePunch;
        SpriteBatch spriteBatch;
        public MouseSprite(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        
        public override void LoadContent()
        {
            mousePunch = this.Game.Content.Load<Texture2D>("Punch");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mouseLoc = MouseSprite.GetState().Position.ToVector2();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
