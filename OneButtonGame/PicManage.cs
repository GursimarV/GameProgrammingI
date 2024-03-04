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
        private Texture2D PunchTexture { get; }
        private SpriteFont Font { get; }
        private List<Punch> _punch = new();
        public int counter {  get; set; }

        public PicManage() 
        {
            PunchTexture = OneButtonController.Content.Load<Texture2D>("Punch");
            Font = OneButtonController.Content.Load<SpriteFont>("Font");
        }

        public Punch AddPunch(Vector2 position)
        {
            Punch p = new(PunchTexture, position);
            _punch.Add(p);

            return p;
        }

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
            OneButtonController.spriteBatch.DrawString(Font, counter.ToString(), new(10,10), Color.Black);
        }
    }
}
