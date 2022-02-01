using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class SpaceShip : SimpleObject
    {
        #region fields
        /// <summary>
        /// Speed
        /// </summary>
        protected double speedPixelPerSecond = 100;

        /// <summary>
        /// Missile (null if not shot)
        /// </summary>
        public Missile missile;
        #endregion

        #region constructor
        /// <summary>
        /// Build a new SpaceShip
        /// </summary>
        /// <param name="x">abscisse of the SpaceShip</param>
        /// <param name="y">ordinnate of the SpaceShip</param>
        /// <param name="lives">number of lives of the SpaceShip</param>
        /// <param name="image">sprite of the SpaceShip</param>
        public SpaceShip(double x, double y, int lives, Bitmap image, Side side) : base(x, y, lives, image, side)
        {
            ;
        }
        #endregion

        #region methods
        /// <summary>
        /// Update the state of the SpaceShip
        /// </summary>
        /// <param name="gameInstance">instance of the current game</param>
        /// <param name="deltaT">time ellapsed in seconds since last call to Update</param>
        public override void Update(Game gameInstance, double deltaT)
        {
            ;
        }

        public void Shoot()
        {
            if (this.missile == null || !this.missile.IsAlive())
            {
                int offset = (this.ObjectSide == Side.Ally) ? -(SpaceInvaders.Properties.Resources.shoot1.Height) : (SpaceInvaders.Properties.Resources.shoot1.Height);
                double fireOrdinnate = this.Position.GetY() + offset;
                int lives = (this.ObjectSide == Side.Ally) ? 2 : 1;
                this.missile = new Missile((this.Position.GetX() + (this.Image.Width / 2)), fireOrdinnate, lives, SpaceInvaders.Properties.Resources.shoot1, this.ObjectSide)
                {
                    Speed = (this.ObjectSide == Side.Ally) ? -300 : 100
                };
            }
        }

        protected override void OnCollision(Missile m, int numberOfPixelsInCollision)
        {
            int min = (this.Lives < m.Lives) ? this.Lives : m.Lives;
            this.Lives -= min;
            m.Lives -= min;
        }
        #endregion
    }
}
