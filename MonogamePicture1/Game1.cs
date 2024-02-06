using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogamePicture1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SpriteFont _font;


        public Texture2D _Hydregion;
        public Texture2D _Latios;
        public Texture2D _Zoroak;


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

            _Hydregion = Content.Load<Texture2D>("Hydregion");
            _Latios = Content.Load<Texture2D>("Latios");
            _Zoroak = Content.Load<Texture2D>("Zoroak");
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
            GraphicsDevice.Clear(Color.DarkTurquoise);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "These are my three favorite Pokemon!!!", new Vector2(102, 102), Color.Gray);
            _spriteBatch.DrawString(_font, "These are my three favorite Pokemon!!!", new Vector2(101, 101), Color.DarkGray);
            _spriteBatch.DrawString(_font, "These are my three favorite Pokemon!!!", new Vector2(100, 100), Color.Black);

            _spriteBatch.Draw(_Hydregion, new Vector2(75, 200), Color.White);
            _spriteBatch.Draw(_Latios, new Vector2(250, 200), Color.White);
            _spriteBatch.Draw(_Zoroak, new Vector2(500, 200), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}