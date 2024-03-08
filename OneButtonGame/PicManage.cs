using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame
{
    internal class PicManage : DrawableGameComponent
    {
        private Texture2D PunchTexture { get; set; }
        private SpriteFont Font { get; set; }
        private List<Punch> _punch = new();
        public int Counter { get; set; }

        public PicManage(Game game) : base(game)
        {
           
        }

        protected override void LoadContent()
        {
            PunchTexture = this.Game.Content.Load<Texture2D>("Punch");
            Font = this.Game.Content.Load<SpriteFont>("Font");

            base.LoadContent();
        }

        //public Punch AddPunch(Vector2 texture position)
        //{
        //    //Punch p = new(PunchTexture, texture, position);
        //    //_punch.Add(p);

        //    //return p;
        //}

        public void Update()
        {
            foreach (var item in _punch)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (var item in _punch)
            {
                item.Draw();
            }
            //obc.spriteBatch.DrawString(Font, Counter.ToString(), new(10,10), Color.Black);
        }
    }
}
