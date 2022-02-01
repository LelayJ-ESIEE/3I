using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class SizeComponent : Component
    {
        public Vector2D Size
        {
            get;
            set;
        }

        public SizeComponent(double pX = 0, double pY = 0)
        {
            this.Size = new Vector2D(pX, pY);
        }
    }
}
