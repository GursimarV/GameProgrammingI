using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using System.Drawing;

namespace MonoGamePerformanceTest
{
    public class DrawableSprite : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D Texture;
        public Vector2 Loc;
        public Vector2 Dir;
        public float Speed;
        public float Rotate;

        public string TextureName;
        public Vector2 Origin;

        SpriteBatch sb;

        public DrawableSprite(Game game) : base(game)
        {
        }
        public DrawableSprite(Game game, string _textureName) : base(game)
        {
            TextureName = _textureName;
        }

        public override void Initialize()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            Speed = 1;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            sb = new SpriteBatch(graphics.GraphicsDevice);

            Loc = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2, this.Game.GraphicsDevice.Viewport.Height / 2);
            Dir = new Vector2(1, 0);
            Speed = 100.0f;
            Rotate = 0.0f;
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(Texture, new Rectangle((int)Loc.X, (int)Loc.Y, Texture.Width, Texture.Height), null, Color.White, 0, Origin, SpriteEffects.None, 0);
            sb.End();
            base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            this.Loc += this.Dir * this.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }
    }
}
