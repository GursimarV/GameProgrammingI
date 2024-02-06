﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Credit to Jeff Meyers
// From GameProgrammingI github, SimpleMovementJump

namespace MonoGameModifyJump
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Loc, Dir;
        public float SpeedMax;
    }
}
