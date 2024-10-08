﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ArenaDeBatalha.GameLogic
{
    public abstract class GameObject
    {
        #region Game Object Properties
        public Bitmap Sprite { get; set; }
        public bool Active { get; set; }
        public int Speed { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Widht { get { return this.Sprite.Width; } }
        public int Height { get { return this.Sprite.Height; } } 
        public Size Bounds { get; set; }
        public Rectangle Rectangle { get; set; }
        public Stream Sound { get; set; }
        public Graphics Screen { get; set; }
        private SoundPlayer soundPlayer { get; set; }
        #endregion

        #region Game Object Methods

        public abstract Bitmap GetSprite();

        public GameObject(Size bounds, Graphics screen)
        {
            this.Bounds = bounds;
            this.Screen = screen;
            this.Active = true;
            this.soundPlayer = new SoundPlayer();
            this.Sprite = this.GetSprite();
            this.Rectangle = new Rectangle(this.Left, this.Top, this.Widht, this.Height);

        }

        public virtual void UpdateObject()
        {
            this.Rectangle = new Rectangle(this.Left, this.Top, this.Widht, this.Height);
            this.Screen.DrawImage(this.Sprite, this.Rectangle);
        }

        public virtual void MoveLeft()
        {
            if (this.Left > 0)
            {
                this.Left -= this.Speed;
            }
        }
        public virtual void MoveRight()
        {
            if (this.Left < this.Bounds.Width - this.Widht)
            {
                this.Left += this.Speed;
            }
        }
        public virtual void MoveDown()
        {
            this.Top += this.Speed;
            
        }
        public virtual void MoveUp()
        {
            this.Top -= this.Speed;

        }

        public bool IsOutOfBounds()
        {
            return(this.Top > this.Bounds.Height + this.Height) || (this.Top < -this.Height) || (this.Left > this.Bounds.Width + this.Widht) || (this.Left < -this.Widht);


        }
        public void PlaySound()
        {
            soundPlayer.Stream = this.Sound;
            soundPlayer.Play();
        }
        public bool IsCollidingWith(GameObject gameObject)
        {
            if (this.Rectangle.IntersectsWith(gameObject.Rectangle))
            {
                this.PlaySound();
                return true;
            }
            else return false;
        }

        public void Destroy()
        {
            this.Active = false;
        }

        #endregion
    }
}
