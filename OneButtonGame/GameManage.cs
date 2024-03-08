using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame
{
    internal class GameManage : DrawableGameComponent
    {
        private PicManage _pic;
        private SpriteFont _font;
        OneButtonController obc;

        public GameManage(Game game, OneButtonController obc) : base(game)
        {
            this.obc = obc;
            this._pic = new PicManage(game);

            this.Game.Components.Add(_pic);

            //_timer = new(_font, new(300, 300), 5f);
            //_timer.OnTimer += IncreaseCounter;
            //_timer.StartStop();
            //_timer.Repeat = true;
        }

        protected override void LoadContent()
        {
            _font = this.Game.Content.Load<SpriteFont>("Font");
            _pic.Initialize();
            base.LoadContent();
        }

        public void Action(object sender, EventArgs e)
        {
            _pic.Counter++;
        }

        public override void Update(GameTime gameTime)
        {
            _pic.Update();
            base.Update(gameTime);
        }

        public void Draw()
        {
            _pic.Draw();
            //obc.spriteBatch.DrawString(_font, _counter.ToString(), _counterPosition, Color.Black);
        }
    }
}
