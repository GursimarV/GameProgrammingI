﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreakoutStep1
{
    public class MonogameBlock : DrawableSprite
    {
        protected Block block;

        protected string NormalTextureName, HitTextureName;
        protected Texture2D NormalTexture, HitTexture;

        private BlockState blockstate;
        public BlockState BlockState
        {
            get { return this.block.BlockState = this.blockstate; } //encapulsate block.BlockState
            set { this.block.BlockState = this.blockstate = value; }
        }

        public MonogameBlock(Game game)
        : base(game)
        {
            this.block = new Block();
            NormalTextureName = "block_blue";
            HitTextureName = "block_bubble";


        }

        protected virtual void UpdateBlockTexture()
        {
            switch (block.BlockState)
            {
                case BlockState.Normal:
                    this.Visible = true;
                    this.spriteTexture = NormalTexture;
                    break;
                case BlockState.Hit:
                    this.spriteTexture = HitTexture;
                    break;
                case BlockState.Broken:
                    this.spriteTexture = NormalTexture;
                    //this.enabled = false;
                    this.Visible = false; //don't show block
                    break;
            }
        }

        protected override void LoadContent()
        {
            this.NormalTexture = this.Game.Content.Load<Texture2D>(NormalTextureName);
            this.HitTexture = this.Game.Content.Load<Texture2D>(HitTextureName);
            UpdateBlockTexture(); //notice this is in loadcontent not the constuctor
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            block.UpdateBlockState();
            UnityBlockUpdate();
        }

        protected virtual void UnityBlockUpdate()
        {
            UpdateBlockTexture();
        }

        public void Hit()
        {
            this.block.Hit();
        }
    }
}