using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGamePerformanceTest
{
    public class Luigi : DrawableSprite
    {
        KeyboardHandler keyBoard;

        public Luigi(Game game) : base(game)
        {
            keyBoard = new KeyboardHandler();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteTexture = this.Game.Content.Load<Texture2D>("Luigi");
        }

        public override void Update(GameTime gameTime)
        {

            UpdateLuigi(lastUpdateTime);
            base.Update(gameTime);
        }

        private void UpdateLuigi(float lastUpdateTime)
        {
            GamePadState gamePad1State = GamePad.GetState(PlayerIndex.One);

            UpdateKeyboard(lastUpdateTime);
        }

        private void UpdateKeyboard(float lastUpdateTime)
        {
            Vector2 LuigiKeyDir = new Vector2(0, 0);
            keyBoard.Update();

            if (keyBoard.IsKeyDown(Keys.Left))
            {
                //Flip Horizontal

                LuigiKeyDir += new Vector2(-1, 0);
            }
            if (keyBoard.IsKeyDown(Keys.Right))
            {
                //No new sprite Effects

                LuigiKeyDir += new Vector2(1, 0);
            }
            if (keyBoard.IsKeyDown(Keys.Up))
            {

                LuigiKeyDir += new Vector2(0, -1);
            }
            if (keyBoard.IsKeyDown(Keys.Down))
            {

                LuigiKeyDir += new Vector2(0, 1);
            }
            if (LuigiKeyDir.Length() > 0)
            {

                float RotationAngleKey = (float)Math.Atan2(
                        LuigiKeyDir.X,
                        LuigiKeyDir.Y * -1);

                Rotate = (float)MathHelper.ToDegrees(
                    RotationAngleKey - (float)(Math.PI / 2));


                Loc += ((LuigiKeyDir * (lastUpdateTime / 1000)) * Speed);      //Simple Move PacMan by PacManDir
            }
        }
    }
}
