using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutStep1
{
    internal class LeveLThree : BlockManager
    {
        public LeveLThree(Game1 game, Ball b) : base(game, b)
        {
            ScoreManager.Level = 3;
        }

        protected override void LoadLevel()
        {
            base.LoadLevel();
        }
    }
}
