using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Bunker : SimpleObject
    {
        public Bunker(double x, double y): base(x, y, 1, SpaceInvaders.Properties.Resources.bunker, Side.Neutral)
        {
            ;
        }

        /// <summary>
        /// Update the state of the bunker
        /// </summary>
        /// <param name="gameInstance">instance of the current game</param>
        /// <param name="deltaT">time ellapsed in seconds since last call to Update</param>
        public override void Update(Game gameInstance, double deltaT)
        {
            ;
        }

        protected override void OnCollision(Missile m, int numberOfPixelsInCollision)
        {
            m.Lives = 0;
        }
    }
}
