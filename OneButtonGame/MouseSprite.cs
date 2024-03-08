using System;
using System.Threading.Tasks.Sources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneButtonGame
{
    public class MouseSprite : DrawableGameComponent
    {
        Vector2 mouseLoc;
        Texture2D mousePunch;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Vector2 _boxingbagPosition = new Vector2(600, 300);
        const int boxingbagRadius = 150;
        MouseState mState;
        bool mReleased = true;
        public int score = 0;
        Timer time;
        public MouseSprite(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            mousePunch = this.Game.Content.Load<Texture2D>("Punch");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = this.Game.Content.Load<SpriteFont>("Font");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mouseLoc = Mouse.GetState().Position.ToVector2();

            //Got Help from here: https://www.youtube.com/watch?v=sPH-sNTSrhw&t=2333s
            //Mouse State
            mState = Mouse.GetState();

            //When the mouse left clicked gets pressed
            if(mState.LeftButton == ButtonState.Pressed && mReleased == true) 
            {
                float mouseTargetDist = Vector2.Distance(_boxingbagPosition, mState.Position.ToVector2());
                //if the mouse clicks within the raidus, it adds a point
                if(mouseTargetDist < boxingbagRadius)
                {
                    score++;
                }
               
                mReleased = false;
            }

            if(mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(mousePunch, mouseLoc, Color.White);
            spriteBatch.DrawString(spriteFont, "Click on the Boxing bag to hit it !!!", new Vector2(250, 25), Color.Black);
            spriteBatch.DrawString(spriteFont, "Points:", new Vector2(500, 50), Color.White);
            spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(550,50), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
