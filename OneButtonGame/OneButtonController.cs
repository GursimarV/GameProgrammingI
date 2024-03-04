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
    public static class OneButtonController 
    {
        public static ContentManager Content { get; set; }
        public static SpriteBatch spriteBatch { get; set; }
        public static MouseState MouseState { get; set; }
        public static MouseState LastMouseState { get; set; }
        public static bool Clicked { get; set; }
        public static Rectangle MouseCursor { get; set; }
        public static float Time { get; private set; }
       


        public static void Update(GameTime gamTime)
        {
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();
            Time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Clicked = (MouseState.LeftButton == ButtonState.Pressed) && (LastMouseState.LeftButton == ButtonState.Released);
            MouseCursor = new(MouseState.Position, new(1, 1));
        }
    }
}
