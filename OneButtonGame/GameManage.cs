using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame
{
    internal class GameManage
    {
        private PicManage _pic = new();
        private Timer _timer;
        private SpriteFont _font;
        private Vector2 _counterPosition = new(300, 200);
        private int _counter;

        public GameManage()
        {
            _font = OneButtonController.Content.Load<SpriteFont>("Font");

            _timer = new(_font, new(300, 300), 5f);
            _timer.OnTimer += IncreaseCounter;
            _timer.StartStop();
            _timer.Repeat = true;

            _pic.AddPunch(new Vector2(100, 100));
        }

        public void IncreaseCounter(object sender, EventArgs e)
        {
            _counter++;
        }

        public void Action(object sender, EventArgs e)
        {
            _pic.Counter++;
        }

        
        public void Update()
        {
            _pic.Update();
            _timer.Update();
        }

        public void Draw()
        {
            _pic.Draw();
            OneButtonController.spriteBatch.DrawString(_font, _counter.ToString(), _counterPosition, Color.Black);
            _timer.Draw();
        }
    }
}
