using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameInterestingMove
{
    internal class Star : Sprite
    {
        public Star(Game game) : this(game, 100)
        {

        }

        public Star(Game game, int Speed) : base(game)
        {
            TextureName = "Star";
            this.SpeedMax = Speed;
        }

        internal void StartMovin()
        {
            this.Dir = new Vector2(1, 1);
        }
    }
}
