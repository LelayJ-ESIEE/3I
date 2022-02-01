using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceInvaders
{
    abstract class SimpleObject : GameObject
    {
        #region properties
        /// <summary>
        /// Position
        /// </summary>
        public Vector2D Position
        {
            get;
            set;
        }

        /// <summary>
        /// Lives
        /// </summary>
        public int Lives
        {
            get;
            set;
        }

        /// <summary>
        /// Sprite
        /// </summary>
        public Bitmap Image
        {
            get;
            set;
        }
        #endregion

        #region constructor
        public SimpleObject(double x, double y, int lives, Bitmap image, Side side) : base(side)
        {
            this.Position = new Vector2D(x, y);
            this.Lives = lives;
            this.Image = new Bitmap(image);
        }
        #endregion

        #region methods
        /// <summary>
        /// Render the game object
        /// </summary>
        /// <param name="gameInstance">instance of the current game</param>
        /// <param name="graphics">graphic object where to perform rendering</param>
        public override void Draw(Game gameInstance, Graphics graphics)
        {
            float positionX = (float)this.Position.GetX();
            float positionY = (float)this.Position.GetY();
            Bitmap image = this.Image;
            graphics.DrawImage(image, positionX, positionY, image.Width, image.Height);
        }

        /// <summary>
        /// Determines if object is alive. If false, the object will be removed automatically.
        /// </summary>
        /// <returns>Am I alive ?</returns>
        public override bool IsAlive()
        {
            return this.Lives > 0;
        }

        /// <summary>
        /// Processes the collision with a missile
        /// </summary>
        /// <param name="m">a Missile</param>
        public override void Collision(Missile m)
        {
            if (this != m && this.ObjectSide != m.ObjectSide && this.HitBoxesCollide(m))
            {
                this.PixelCollision(m);
            }
        }

        /// <summary>
        /// Determines if the hitboxes of the Objext and the Missile are colliding. If so, the collision will be checked pixel by pixel.
        /// </summary>
        /// <param name="m">a Missile</param>
        /// <returns>Are our hitboxes colliding ?</returns>
        protected bool HitBoxesCollide(Missile m)
        {
            if (this.Position.GetX() <= m.Position.GetX() + m.Image.Width && this.Position.GetX() + this.Image.Width >= m.Position.GetX())
            {
                if (this.Position.GetY() + this.Image.Height >= m.Position.GetY() && this.Position.GetY() <= m.Position.GetY() + m.Image.Height)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if any pixel is in collision between the Object and the Missile. If so, the collision will be managed.
        /// </summary>
        /// <param name="m">a Missile</param>
        protected void PixelCollision(Missile m)
        {
            int counter = 0;
            for (int i = 0; i < m.Image.Height; i++)
            {
                for (int j = 0; j < m.Image.Width; j++)
                {
                    Vector2D pixelPositionOnScreen = new Vector2D(m.Position.GetX() + j, m.Position.GetY() + i);
                    Vector2D pixelPositionInBunker = pixelPositionOnScreen - this.Position;

                    bool pixelInsideX = (pixelPositionInBunker.GetX() >= 0) && (pixelPositionInBunker.GetX() < this.Image.Width);
                    bool pixelInsideY = (pixelPositionInBunker.GetY() >= 0) && (pixelPositionInBunker.GetY() < this.Image.Height);
                    bool missilePixelIsBlack = m.Image.GetPixel(j, i).ToArgb() == System.Drawing.Color.Black.ToArgb();
                    if (pixelInsideX && pixelInsideY && missilePixelIsBlack)
                    {
                        int colorBunkerPixel = this.Image.GetPixel((int)pixelPositionInBunker.GetX(), (int)pixelPositionInBunker.GetY()).ToArgb();
                        bool bunkerPixelIsBlack = colorBunkerPixel == System.Drawing.Color.Black.ToArgb();
                        if (bunkerPixelIsBlack)
                        {
                            this.Image.SetPixel((int)pixelPositionInBunker.GetX(), (int)pixelPositionInBunker.GetY(), System.Drawing.Color.Transparent);
                            counter += 1;
                        }
                    }
                }
            }
            if (counter > 0)
                this.OnCollision(m, counter);
        }

        /// <summary>
        /// Manage collision between the Object and the Missile
        /// </summary>
        /// <param name="m">the colliding Missile</param>
        /// <param name="numberOfPixelsInCollision">the number of pixels involved in the collision</param>
        protected abstract void OnCollision(Missile m, int numberOfPixelsInCollision);
        #endregion
    }
}
