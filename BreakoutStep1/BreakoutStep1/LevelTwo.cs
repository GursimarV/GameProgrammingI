using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutStep1
{
    internal class LevelTwo : BlockManager
    {
        public LevelTwo(Game1 game, Ball b) : base(game, b)
        {
            ScoreManager.Level = 2;
        }

        protected override void LoadLevel()
        {
            base.LoadLevel();
        }
    }
}
