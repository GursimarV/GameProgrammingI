using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            OneButtonController.Content = Content;
            _gm = new();

            _font = Content.Load<SpriteFont>("Font");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _matt = Content.Load<Texture2D>("Matt");
            _boxingbag = Content.Load<Texture2D>("WiiBoxingBag");
            OneButtonController.spriteBatch = _spriteBatch;
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            // TODO: Add your update logic here

            OneButtonController.Update();
            OneButtonController.Update(gameTime);
            _gm.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _gm.Draw();

            _spriteBatch.Draw(_matt, new Vector2(250, 250), Color.White);
            _spriteBatch.Draw(_boxingbag, new Vector2(500,500), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}