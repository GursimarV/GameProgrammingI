using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameModifyJump
{
    /// <summary>
    /// Simple Movement For Jumping
    /// Uses a simple class called KeyboardHandler for input
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Adding the different sprite characters
        /// </summary>

        MarioChar mario;
        MarioChar luigi;
        MarioChar wario;
        MarioChar waluigi;
        MarioChar yoshi;

        SpriteFont font;
        string OutputData;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Put two different methods for adding the characters as a new MarioChar and to load the characters
            AddMarioChars();
            LoadMarioChar();

            font = Content.Load<SpriteFont>("Arial");
        }

        private void AddMarioChars()
        {
            //Adding the different Mario Characters instances to the MarioChar 
            mario = new MarioChar(1);
            luigi = new MarioChar(2);
            wario = new MarioChar(3);
            waluigi = new MarioChar(4);
            yoshi = new MarioChar(5);
        }

        private void LoadMarioChar()
        {
            //Loading all the Mario Characters, their start location, max speed, and the direction 
            mario.Texture = Content.Load<Texture2D>("Mario");
            mario.Loc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            mario.Dir = new Vector2(0, 50);
            mario.SpeedMax = 200;

            luigi.Texture = Content.Load<Texture2D>("Luigi");
            luigi.Loc = new Vector2(250, 250);
            luigi.Dir = new Vector2(50, 0);
            luigi.SpeedMax = 250;

            wario.Texture = Content.Load<Texture2D>("Wario");
            wario.Loc = new Vector2(300, 300);
            wario.Dir = new Vector2(50, 0);
            wario.SpeedMax = 200;

            waluigi.Texture = Content.Load<Texture2D>("Waluigi");
            waluigi.Loc = new Vector2(400, 400);
            waluigi.Dir = new Vector2(0, 50);
            waluigi.SpeedMax = 200;

            yoshi.Texture = Content.Load<Texture2D>("Yoshi");
            yoshi.Loc = new Vector2(500, 100);
            yoshi.Dir = new Vector2(50, 0);
            yoshi.SpeedMax = 250;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Elapsed time since last update
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Update the times of the movement, input from keyboard, and making the character stay on screen for each Mario Characters

            MarioUpdate(time);
            LuigiUpdate(time);
            WarioUpdate(time);
            WaluigiUpdate(time);
            YoshiUpdate(time);

            base.Update(gameTime);
        }

        private void MarioUpdate(float time)
        {
            mario.UpdateMarioCharMove(time);
            mario.UpdateKeepMarioCharOnScreen(GraphicsDevice);
            mario.UpdateInputFromKeyboard();

            OutputData = string.Format("MarioDir:{0}\nMarioLoc:{1}\nGravityDir:{2}\nGravityAccel:{3}\nTime:{4}\njumpHeight:{5}", mario.Dir.ToString(), mario.Loc.ToString(), mario.GravityDir.ToString(), mario.GravityAccel.ToString(), time, mario.jumpHeight);
        }

        private void LuigiUpdate(float time)
        {
            luigi.UpdateMarioCharMove(time);
            luigi.UpdateKeepMarioCharOnScreen(GraphicsDevice);
            luigi.UpdateInputFromKeyboard();
        }

        private void WarioUpdate(float time)
        {
            wario.UpdateMarioCharMove(time);
            wario.UpdateKeepMarioCharOnScreen(GraphicsDevice);
            wario.UpdateInputFromKeyboard();
        }

        private void WaluigiUpdate(float time)
        {
            waluigi.UpdateMarioCharMove(time);
            waluigi.UpdateKeepMarioCharOnScreen(GraphicsDevice);
            waluigi.UpdateInputFromKeyboard();
        }

        private void YoshiUpdate(float time)
        {
            yoshi.UpdateMarioCharMove(time);
            yoshi.UpdateKeepMarioCharOnScreen(GraphicsDevice);
            yoshi.UpdateInputFromKeyboard();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Draw the different Mario Characters, their location, and color
            spriteBatch.Draw(mario.Texture, mario.Loc, Color.White);
            spriteBatch.Draw(luigi.Texture, luigi.Loc, Color.White);
            spriteBatch.Draw(wario.Texture, wario.Loc, Color.White);
            spriteBatch.Draw(waluigi.Texture, waluigi.Loc, Color.White);
            spriteBatch.Draw(yoshi.Texture, yoshi.Loc, Color.White);

            spriteBatch.DrawString(font, OutputData, new Vector2(10, 10), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}