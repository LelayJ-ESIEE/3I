using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceInvaders
{
    class Missile : SimpleObject
    {
        #region properties
        /// <summary>
        /// Speed
        /// </summary>
        public double Speed
        {
            get;
            set;
        }
        #endregion

        #region constructor
        /// <summary>
        /// Build a new SpaceShip
        /// </summary>
        /// <param name="x">abscisse of the Missile</param>
        /// <param name="y">ordinnate of the Missile</param>
        /// <param name="lives">number of lives of the Missile</param>
        /// <param name="image">sprite of the Missile</param>
        public Missile(double x, double y, int lives, Bitmap image, Side side) : base(x, y, lives, image, side)
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
            Vector2D vitesse = new Vector2D(0, this.Speed);
            this.Position += vitesse*deltaT;
            if (this.Position.GetY() < 0 || (this.Position.GetY() + this.Image.Height) > gameInstance.gameSize.Height)
                this.Lives = 0;

            foreach (GameObject gameObject in gameInstance.gameObjects)
            {
                gameObject.Collision(this);
            }
        }

        protected override void OnCollision(Missile m, int numberOfPixelsInCollision)
        {
            this.Lives = 0;
            m.Lives = 0;
        }
        #endregion
    }
}
