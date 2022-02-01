using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class EnemyBlock : GameObject
    {
        #region fields
        private readonly HashSet<SpaceShip> enemyShips;
        private readonly int baseWidth;
        private Vector2D speed;
        private double randomShootProbability;
        #endregion

        #region properties
        public Size Size
        {
            get;
            set;
        }

        public Vector2D Position
        {
            get;
            set;
        }

        #endregion

            #region constructor
        public EnemyBlock(double x, double y, int baseWidth) : base(Side.Enemy)
        {
            this.Position = new Vector2D(x, y);
            this.baseWidth = baseWidth;
            this.Size = new Size(0, 0);
            this.speed = new Vector2D(20, 0);
            this.enemyShips = new HashSet<SpaceShip>();
            this.randomShootProbability = 0.1;
        }
        #endregion

        #region methods
        public void AddLine(int nbShips, int nbLives, Bitmap shipImage)
        {
            int offset = 0;
            if(this.Size.Height > 0)
            {
                offset = this.Size.Height + 5;
            }
            if(nbShips > 1)
            {
                for(int i = 0; i < nbShips; i++)
                {
                    SpaceShip enemyShip = new SpaceShip(this.Position.GetX() + i * (baseWidth - shipImage.Width) / (nbShips - 1), this.Position.GetY() + offset, nbLives, shipImage, Side.Enemy);
                    this.enemyShips.Add(enemyShip);
                }
            }
            else
            {
                SpaceShip enemyShip = new SpaceShip(this.Position.GetX() + (baseWidth - shipImage.Width) / 2, this.Position.GetY() + offset, nbLives, shipImage, Side.Enemy);
                this.enemyShips.Add(enemyShip);
            }
            this.UpdateSize();
        }

        public void UpdateSize()
        {
            int width = 0;
            int height = 0;
            foreach (SpaceShip enemyShip in enemyShips)
            {
                if (width < enemyShip.Position.GetX() + enemyShip.Image.Width - this.Position.GetX())
                    width = (int)(enemyShip.Position.GetX() + enemyShip.Image.Width - this.Position.GetX());
                if (height < enemyShip.Position.GetY() + enemyShip.Image.Height - this.Position.GetY())
                    height = (int) (enemyShip.Position.GetY() + enemyShip.Image.Height - this.Position.GetY());
            }
            this.Size = new Size(width, height);
        }


        public void UpdatePosition()
        {
            double x = this.Position.GetX() + this.Size.Width;
            double y = this.Position.GetY() + this.Size.Height;
            foreach (SpaceShip enemyShip in enemyShips)
            {
                if (x > enemyShip.Position.GetX())
                    x = enemyShip.Position.GetX();
                if (y > enemyShip.Position.GetY())
                    y = enemyShip.Position.GetY();
            }
            this.Position = new Vector2D(x,y);
        }

        public override void Update(Game gameInstance, double deltaT)
        {
            if (this.Position.GetX() + this.speed.GetX()*deltaT < 0 || this.Position.GetX() + this.Size.Width + this.speed.GetX()*deltaT > gameInstance.gameSize.Width)
            {
                double newX;
                if (this.Position.GetX() + this.speed.GetX() < 0)
                    newX = -(this.Position.GetX());
                else
                    newX = gameInstance.gameSize.Width - this.Size.Width - this.Position.GetX();
                this.speed *= -1.1;
                this.randomShootProbability *= 1.25;
                Vector2D verticalSpeed = new Vector2D(newX, 20);
                this.Position += verticalSpeed;
                foreach (SpaceShip enemyShip in enemyShips)
                {
                    enemyShip.Position += verticalSpeed;
                }
            }
            else
            {
                this.Position += this.speed * deltaT;
                foreach (SpaceShip enemyShip in enemyShips)
                {
                    enemyShip.Position += this.speed * deltaT;
                }
            }

            Random rand = new Random();
            foreach (SpaceShip enemyShip in enemyShips)
            {
                double r = rand.NextDouble();
                if (r <= randomShootProbability * deltaT)
                {
                    enemyShip.Shoot();
                    gameInstance.AddNewGameObject(enemyShip.missile);
                }
            }
        }

        public override void Draw(Game gameInstance, Graphics graphics)
        {
            foreach (SpaceShip enemyShip in this.enemyShips)
            {
                enemyShip.Draw(gameInstance, graphics);
            }
        }

        public override bool IsAlive()
        {
            return this.enemyShips.Count() > 0;
        }

        public override void Collision(Missile m)
        {
            HashSet<SpaceShip> deadEnemies = new HashSet<SpaceShip>();
            foreach (SpaceShip enemyShip in this.enemyShips)
            {
                enemyShip.Collision(m);
                if (!enemyShip.IsAlive())
                    deadEnemies.Add(enemyShip);
            }
            foreach (SpaceShip enemyShip in deadEnemies)
            {
                this.enemyShips.Remove(enemyShip);
            }
            this.UpdatePosition();
            this.UpdateSize();
        }


        #endregion
    }
}
