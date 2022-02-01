using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Components
{
    class HealthComponent : Component
    {
        public int Health
        {
            get;
            set;
        }

        public HealthComponent(int pHealth = 0)
        {
            this.Health = pHealth;
        }
    }
}
