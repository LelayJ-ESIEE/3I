using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceInvaders.Components
{
    class SpriteComponent : Component
    {
        public Bitmap Sprite
        {
            get;
            set;
        }

        public SpriteComponent(string filename)
        {
            this.Sprite = new Bitmap(filename);
        }
    }
}
