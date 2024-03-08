using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace OneButtonGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Texture2D _matt;

        public Texture2D _boxingbag;

        private GameManage _gm;

        private SpriteFont _font;

        OneButtonController obc;

        MouseSprite mouseSprite;

        Timer timer;

        private string _winText = "";

        private string _lostText = ""; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

           obc = new OneButtonController(this);
            this.Components.Add(obc);
           _gm = new GameManage(this, obc);
            this.Components.Add(_gm);
           mouseSprite = new MouseSprite(this);
            this.Components.Add(mouseSprite);
           timer = new Timer(this);
            this.Components.Add(timer);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            obc.Content = Content;

            _font = Content.Load<SpriteFont>("Font");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _matt = Content.Load<Texture2D>("Matt");
            _boxingbag = Content.Load<Texture2D>("WiiBoxingBag");
            obc.spriteBatch = _spriteBatch;
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            // TODO: Add your update logic here
            //When time reaches 0, if you score 50 points or above, you win
            if(timer.timerTime <= 0)
            {
                if (mouseSprite.score >= 50)
                {
                    _winText = "Congrats You Win!!!";
                }

                //if you score less than 50 points, you lose
                else if (mouseSprite.score <= 50)
                {
                    _lostText = "Too Bad, Try Again!!!";
                }

                //Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _gm.Draw();

            _spriteBatch.Draw(_matt, new Rectangle(25, 150, 256, 256), Color.White);
            _spriteBatch.Draw(_boxingbag, new Rectangle(475, 150, 256, 256), Color.White);

            //Reads the text from above when timer reaches 0 and the player scores 50 or more points
            if (timer.timerTime <= 0 && mouseSprite.score >= 50)
            {
                _spriteBatch.DrawString(_font, _winText, new Vector2(300, 100), Color.Black);
                _spriteBatch.DrawString(_font, "Press Escape to exit!", new Vector2(300, 125), Color.Red);
            }
            //Reads the text from above when timer reaches 0 and the player scores less than 50 points
            else if (timer.timerTime <= 0 && mouseSprite.score <= 50)
            {
                _spriteBatch.DrawString(_font, _lostText, new Vector2(300, 100), Color.Black);
                _spriteBatch.DrawString(_font, "Press Escape to exit!", new Vector2(300, 125), Color.Red);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}