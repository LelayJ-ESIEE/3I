using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class SpeedComponent : Component
    {
        public Vector2D Speed
        {
            get;
            set;
        }

        public SpeedComponent(double pX = 0, double pY = 0)
        {
            this.Speed = new Vector2D(pX, pY);
        }
    }
}
