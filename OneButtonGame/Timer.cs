using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame
{
    internal class Timer : DrawableGameComponent
    {
        private Vector2 _position;
        private SpriteFont _font;
        private Vector2 _textPosition;
        private string _text;
        private float _timeLength;
        private float _timeLeft;
        private bool _active;
        public bool Repeat { get; set; }

        public Timer(SpriteFont font, Vector2 pos, float len) : base(game)
        {
            _font = font;
            _position = pos;
            _textPosition = new(pos.X + 32, pos.Y + 2);
            _timeLength = len;
            _timeLeft = len;
        }

        private void FormatText()
        {
            _text = TimeSpan.FromSeconds(_timeLeft).ToString(@"mm\:ss\.ff");
        }

        public void StartStop()
        {
            _active = !_active;
        }

        public void Reset()
        {
            _timeLeft = _timeLength;
            FormatText();
        }

        public event EventHandler OnTimer;

        public void Update()
        {
            if (!_active) return;
            _timeLeft -= OneButtonController.Time;

            if (_timeLeft <= 0)
            {
                OnTimer?.Invoke(this, EventArgs.Empty);

                if (Repeat)
                {
                    Reset();
                }
                else
                {
                    StartStop();
                    _timeLeft = 0f;
                }
            }

            FormatText();
        }

        public void Draw()
        {
            OneButtonController.spriteBatch.DrawString(_font, _text, _position, Color.Black);
        }
    }
}
