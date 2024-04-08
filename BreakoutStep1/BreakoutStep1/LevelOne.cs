using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutStep1
{
    internal class LevelOne : BlockManager
    {
        public LevelOne(Game1 game, Ball b) : base(game, b) 
        {
            ScoreManager.Level = 1;
        }

        public override void LoadLevel()
        {
            base.LoadLevel();
        }
    }
}
