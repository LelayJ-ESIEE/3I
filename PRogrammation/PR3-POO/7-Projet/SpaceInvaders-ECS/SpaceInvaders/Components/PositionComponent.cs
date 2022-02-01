using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class PositionComponent : Component
    {
        public Vector2D Position
        {
            get;
            set;
        }

        public PositionComponent(double x = 0, double y = 0)
        {
            this.Position = new Vector2D(x, y);
        }
    }
}
