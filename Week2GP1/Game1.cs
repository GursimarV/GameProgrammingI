using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Week2GP1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SpriteFont _arial;

        public Texture2D _pacman;
        public Vector2 _paclocation;

        public Vector2 _pacdirection; //only a direction
        public int _pacspeed; //magnitiude of the direction

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //the game constuctor can be used to set some graphics settings.
            //_graphics.PreferredBackBufferHeight = 768;
            //_graphics.PreferredBackBufferWidth = 1024;
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            //TargetElapsedTime = TimeSpan.FromTicks(333333);
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
            _arial = Content.Load<SpriteFont>("Arial");

            _pacman = Content.Load<Texture2D>("PacmanSingle");
            _paclocation = new Vector2(150, 150);

            _pacdirection = new Vector2(1,1); //normalized
            _pacspeed = 200; //used to be 200 dependancy pixels per second
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdatePacManMove(gameTime);
            UpdatePacManKeepOnScreen();


            base.Update(gameTime);
        }

        private void UpdatePacManKeepOnScreen()
        {
            //Pacman location plus the pacman texture width less than the graphics viewport width
            if ((this._paclocation.X + _pacman.Width > GraphicsDevice.Viewport.Width)
                ||
                (_paclocation.X < 0))
            {
                //turn around by flipping x and y by multiplying by -1
                _pacdirection.X *= -1;

                //to the pacman warp
                //_paclocation.X -= GraphicsDevice.Viewport.Width;
            }
            if((_paclocation.Y + _pacman.Height > GraphicsDevice.Viewport.Height)
                ||
                (_paclocation.Y < 0))
            {
                _pacdirection.Y *= -1;
            }
        }

        private void UpdatePacManMove(GameTime gameTime)
        {
            //incorrect
            //_paclocation += (_pacdirection * _pacspeed);
            //Time corrected movement
            _paclocation += (_pacdirection * _pacspeed) * ((float)gameTime.ElapsedGameTime.TotalMilliseconds/1000);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Don't do anything but draw in draw

            _spriteBatch.Begin();
            _spriteBatch.Draw(_pacman, _paclocation, Color.White);
            _spriteBatch.DrawString(_arial, "Pacman's Location: " + _paclocation.ToString(), new Vector2(50,50), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}