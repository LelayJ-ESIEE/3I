using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class CanFireComponent : Component
    {
        public bool CanFire
        {
            get;
            set;
        }

        public  CanFireComponent(bool pCanFire = true)
        {
            this.CanFire = pCanFire;
        }
    }
}
