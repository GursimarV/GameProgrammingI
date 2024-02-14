using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameInterestingMove
{
    internal class LuigiChar : Sprite
    {
        public LuigiChar(Game game) : base(game)
        {

        }


        float RotationAngleKey;
        public override void Update(GameTime gameTime)
        {
            UpateLuigiCharKeepOnScreen();

            UpdateLuigiCharSpeed();
            //updated direction
            UpdateKeyboardInput();

            //Angle in radians from vector2
            RotationAngleKey = (float)System.Math.Atan2(
                    this.Dir.X,
                    this.Dir.Y * -1); //y axis is flipped already
            //Find angle in degrees
            this.Rotate = (float)MathHelper.ToDegrees(
                RotationAngleKey - (float)(Math.PI / 2)); //image is rotated facing right already hence the -1/2 PI


            base.Update(gameTime); //Move code from Parent

        }

        private void UpateLuigiCharKeepOnScreen()
        {
            //Turn PacMan Around if it hits the edge of the screen
            if ((this.Loc.X > this.game.GraphicsDevice.Viewport.Width - this.Texture.Width)
                || (this.Loc.X < 0))
            {
                this.Dir *= new Vector2(-1, 0);
            }
            if ((this.Loc.Y > this.game.GraphicsDevice.Viewport.Height - this.Texture.Height)
                || (this.Loc.Y < 0))
            {
                this.Dir *= new Vector2(0, -1);
            }
        }

        private void UpdateLuigiCharSpeed()
        {
            //Speed for next frame
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                this.Speed = 200;
            }
            else
            {
                this.Speed = 0;
            }

        }
        private void UpdateKeyboardInput()
        {
            #region Keyboard Movement
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.Dir += new Vector2(0, 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.Dir += new Vector2(0, -1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.Dir += new Vector2(1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.Dir += new Vector2(-1, 0);
            }

            //normalize vector
            if (this.Dir.Length() >= 1.0)
            {
                this.Dir.Normalize();
            }
            #endregion
        }
    }
}
