using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGamePerformanceTest
{
    public class Luigi : Sprite
    {
        public Luigi(Game game) : base(game)
        {
            TextureName = "Luigi"
        }

        public Luigi(Game game, string texture_Name) : base(game, texture_Name) 
        { 
        
        }
    }
}
