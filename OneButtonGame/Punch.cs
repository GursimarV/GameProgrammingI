using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame
{
    internal class Punch : DrawableGameComponent
    {
        private Texture2D _texture;
        private Vector2 _position;
        private  Rectangle _bounds;
        private Color _color = Color.White; 

        public Punch(Game game, Texture2D texture, Vector2 position) : base(game)
        {
            _texture = texture;
            _position = position;
            _bounds = new((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update()
        {
            //if(//OneButtonController.MouseCursor.Intersects(_bounds))
            //{
            //    _color = Color.Black;
            //    if(//OneButtonController.Clicked)
            //{
            //Click();
            //}
            //}
            //else
            //{
            //_color = Color.White;
            //}
        }

        //public event ButtonHandle OnClick;

        //private void Click()
        //{
            //OnClick?.Invoke(this, EventArgs.Empty);
        //}

        public void Draw()
        {
            //OneButtonController.spriteBatch.Draw(_texture, _position, _bounds, Color.White);
        }
    }
}
