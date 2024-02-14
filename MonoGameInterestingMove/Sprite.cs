using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MonoGameInterestingMove
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Loc, Dir, Origin;
        public float SpeedMax, Rotate;

        public string TextureName { get; set; }

        protected Game game;

        public Sprite(Game game)
        {
            this.game = game;

            this.SpeedMax = 100;
        }

        public virtual void LoadContent()
        {
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "pacmanSingle";       
            Texture = game.Content.Load<Texture2D>(TextureName);
            
            this.Loc = new Vector2(game.GraphicsDevice.Viewport.Width / 2,
                game.GraphicsDevice.Viewport.Height / 2);
            
            this.Dir = new Vector2(0, 0);

            this.Origin = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);

        }

        float time;

        public virtual void Update(GameTime gameTime)
        {
            //Elapsed time since last update will be used to correct movement speed
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Time corrected move. MOves Sprite By Div every Second
            this.Loc = this.Loc + ((this.Dir * this.SpeedMax) * (time / 1000));      //Simple Move PacMan by PacManDir

        }

        public virtual void Draw(SpriteBatch spriteBatch)  
        {
            spriteBatch.Draw(this.Texture,  
                new Rectangle(        
                    (int)this.Loc.X,
                    (int)this.Loc.Y,
                    (int)(this.Texture.Width),
                    (int)(this.Texture.Height)),
                null,   
                Color.White,
                MathHelper.ToRadians(this.Rotate), 
                this.Origin,   
                SpriteEffects.None,
                0);

        }
    }
}
