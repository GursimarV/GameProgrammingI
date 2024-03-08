using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace OneButtonGame
{
    public class OneButtonController : GameComponent
    {
        public OneButtonController(Game game) : base(game) 
        {
            MouseState ms = Mouse.GetState();
        }

        public ContentManager Content { get; set; }
        public  SpriteBatch spriteBatch { get; set; }
        public MouseState MouseState { get; set; }
        public MouseState LastMouseState { get; set; }
        public bool Clicked { get; set; }
        public Rectangle MouseCursor { get; set; }
        public float Time { get; private set; }

        public override void Update(GameTime gameTime) 
        {
            //LastMouseState = MouseState;
            //MouseState = Mouse.GetState();
            //Time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Clicked = (MouseState.LeftButton == ButtonState.Pressed) && (LastMouseState.LeftButton == ButtonState.Released);
            //MouseCursor = new(MouseState.Position, new(1, 1));

            base.Update(gameTime);
        }
    }
}
