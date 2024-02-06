using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SpriteFont _font;

        public Texture2D _pacman;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>("Font");

            _pacman = Content.Load<Texture2D>("PacmanSingle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //ONLY ONCE
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "Hello Monogame!!!", new Vector2(102, 102), Color.Black);
            _spriteBatch.DrawString(_font, "Hello Monogame!!!", new Vector2(101, 101), Color.Gray);
            _spriteBatch.DrawString(_font, "Hello Monogame!!!", new Vector2(100, 100), Color.Aqua);

            _spriteBatch.Draw(_pacman, new Vector2(200, 200), Color.White);
            _spriteBatch.Draw(_pacman, new Vector2(200, 300), Color.Blue);
            _spriteBatch.Draw(_pacman, new Vector2(200, 400), Color.Red);

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}