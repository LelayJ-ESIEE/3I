using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders
{
    class PlayerSpaceShip : SpaceShip
    {
        #region constructor
        /// <summary>
        /// Build a new PlayerShip
        /// </summary>
        /// <param name="x">abscisse of the PlayerSpaceShip</param>
        /// <param name="y">ordinnate of the PlayerSpaceShip</param>
        /// <param name="lives">number of lives of the PlayerSpaceShip</param>
        /// <param name="image">sprite of the PlayerSpaceShip</param>
        public PlayerSpaceShip(double x, double y, int lives, Bitmap image) : base(x, y, lives, image, Side.Ally)
        {
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
            Vector2D vitesse = new Vector2D(this.speedPixelPerSecond * deltaT, 0);
            if (gameInstance.keyPressed.Contains(Keys.Left))
            {
                if (this.Position.GetX() > 0)
                    // move the SpaceShip to the left
                    this.Position -= vitesse;
            }

            if (gameInstance.keyPressed.Contains(Keys.Right))
            {
                if (this.Position.GetX() < (gameInstance.gameSize.Width - this.Image.Width))
                    // move the SpaceShip to the right
                    this.Position += vitesse;
            }

            if (gameInstance.keyPressed.Contains(Keys.Space))
            {
                this.Shoot();
                gameInstance.AddNewGameObject(this.missile);
            }
        }

        public override void Draw(Game gameInstance, Graphics graphics)
        {
            base.Draw(gameInstance, graphics);
            graphics.DrawString("Lives : " + this.Lives, Game.defaultFont, Game.blackBrush, 0, gameInstance.gameSize.Height - Game.defaultFont.Height);
        }
        #endregion
    }
}
