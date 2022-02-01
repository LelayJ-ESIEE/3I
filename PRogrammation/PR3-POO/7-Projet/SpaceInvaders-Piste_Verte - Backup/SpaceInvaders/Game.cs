using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Game
    {

        #region GameObjects management
        /// <summary>
        /// Set of all game objects currently in the game
        /// </summary>
        public HashSet<GameObject> gameObjects = new HashSet<GameObject>();

        /// <summary>
        /// Set of new game objects scheduled for addition to the game
        /// </summary>
        private readonly HashSet<GameObject> pendingNewGameObjects = new HashSet<GameObject>();

        /// <summary>
        /// Schedule a new object for addition in the game.
        /// The new object will be added at the beginning of the next update loop
        /// </summary>
        /// <param name="gameObject">object to add</param>
        public void AddNewGameObject(GameObject gameObject)
        {
            pendingNewGameObjects.Add(gameObject);
        }
        #endregion

        #region game technical elements
        /// <summary>
        /// Size of the game area
        /// </summary>
        public Size gameSize;

        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed = new HashSet<Keys>();

        /// <summary>
        /// Possible states of the game
        /// </summary>
        private enum GameState { Play, Pause, Win, Lost }

        #endregion

        #region static fields (helpers)

        /// <summary>
        /// Singleton for easy access
        /// </summary>
        public static Game game { get; private set; }

        /// <summary>
        /// A shared black brush
        /// </summary>
        public static Brush blackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// A shared simple font
        /// </summary>
        public static Font defaultFont = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        #endregion

        #region fields
        private PlayerSpaceShip playerShip;
        private GameState gameState;
        private EnemyBlock enemies;
        #endregion

        #region constructors
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// 
        /// <returns></returns>
        public static Game CreateGame(Size gameSize)
        {
            if (game == null)
                game = new Game(gameSize);
            return game;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {
            this.gameSize = gameSize;
            this.InitialiseGame();
        }

        #endregion

        #region methods

        public void InitialiseGame()
        {
            this.gameState = GameState.Play;

            // PlayerShip creation : 3 lives, centered at the bottome of the GameForm
            this.playerShip = new PlayerSpaceShip((gameSize.Width / 2) - (SpaceInvaders.Properties.Resources.ship3.Width / 2), (gameSize.Height - SpaceInvaders.Properties.Resources.ship3.Height), 3, SpaceInvaders.Properties.Resources.ship3);
            // Addition of the playerShip to pendingNewGameObjects
            this.AddNewGameObject(this.playerShip);

            // Creation of 3 bunkers
            int bunkerWidth = SpaceInvaders.Properties.Resources.bunker.Width;
            for (int i = 1; i <= 5; i += 2)
            {
                Bunker bunker = new Bunker(i * (this.gameSize.Width - bunkerWidth) / 6, 450);
                this.AddNewGameObject(bunker);
            }

            this.enemies = new EnemyBlock(0, 0, 400);
            this.enemies.AddLine(1, 4, SpaceInvaders.Properties.Resources.ship4);
            this.enemies.AddLine(7, 3, SpaceInvaders.Properties.Resources.ship1);
            this.enemies.AddLine(7, 2, SpaceInvaders.Properties.Resources.ship2);
            this.enemies.AddLine(9, 1, SpaceInvaders.Properties.Resources.ship5);
            this.enemies.AddLine(12, 1, SpaceInvaders.Properties.Resources.ship6);
            this.AddNewGameObject(this.enemies);
        }

        /// <summary>
        /// Force a given key to be ignored in following updates until the user
        /// explicitily retype it or the system autofires it again.
        /// </summary>
        /// <param name="key">key to ignore</param>
        public void ReleaseKey(Keys key)
        {
            keyPressed.Remove(key);
        }

        /// <summary>
        /// Draw the whole game
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {
            if (this.gameState == GameState.Lost)
            {
                g.DrawString("You lose", Game.defaultFont, Game.blackBrush, this.gameSize.Width/2 - 45, this.gameSize.Height / 2);
                return;
            }
            else if (this.gameState == GameState.Win)
            {
                g.DrawString("You Win", Game.defaultFont, Game.blackBrush, this.gameSize.Width / 2 - 50, this.gameSize.Height / 2);
                return;
            }
            else if (this.gameState == GameState.Pause)
                g.DrawString("Pause", Game.defaultFont, Game.blackBrush, 1, 1);

            foreach (GameObject gameObject in gameObjects)
                gameObject.Draw(this, g);       
        }

        /// <summary>
        /// Update game
        /// </summary>
        public void Update(double deltaT)
        {
            // add new game objects
            gameObjects.UnionWith(pendingNewGameObjects);
            pendingNewGameObjects.Clear();

            // Manage GameState
            if (this.keyPressed.Contains(Keys.P))
            {
                if (this.gameState == GameState.Play)
                    this.gameState = GameState.Pause;
                else
                    this.gameState = GameState.Play;
                this.ReleaseKey(Keys.P);
            }
            if (this.playerShip.Lives == 0 || this.enemies.Position.GetY() + this.enemies.Size.Height >= this.playerShip.Position.GetY())
            {
                this.gameState = GameState.Lost;
                this.playerShip.Lives = 0;
            }
            if (!this.enemies.IsAlive())
            {
                this.gameState = GameState.Win;
            }
            if((this.gameState == GameState.Lost || this.gameState == GameState.Win) && this.keyPressed.Contains(Keys.Space))
            {
                this.gameObjects.RemoveWhere(gameObjects => true);
                this.gameState = GameState.Play;

                // PlayerShip creation : 3 lives, centered at the bottome of the GameForm
                this.playerShip = new PlayerSpaceShip((gameSize.Width / 2) - (SpaceInvaders.Properties.Resources.ship3.Width / 2), (gameSize.Height - SpaceInvaders.Properties.Resources.ship3.Height), 3, SpaceInvaders.Properties.Resources.ship3);
                // Addition of the playerShip to pendingNewGameObjects
                this.AddNewGameObject(this.playerShip);

                // Creation of 3 bunkers
                int bunkerWidth = SpaceInvaders.Properties.Resources.bunker.Width;
                for (int i = 1; i <= 5; i += 2)
                {
                    Bunker bunker = new Bunker(i * (this.gameSize.Width - bunkerWidth) / 6, 450);
                    this.AddNewGameObject(bunker);
                }

                this.enemies = new EnemyBlock(0, 0, 400);
                this.enemies.AddLine(1, 4, SpaceInvaders.Properties.Resources.ship4);
                this.enemies.AddLine(7, 3, SpaceInvaders.Properties.Resources.ship1);
                this.enemies.AddLine(7, 2, SpaceInvaders.Properties.Resources.ship2);
                this.enemies.AddLine(9, 1, SpaceInvaders.Properties.Resources.ship5);
                this.enemies.AddLine(12, 1, SpaceInvaders.Properties.Resources.ship6);
                this.AddNewGameObject(this.enemies);
                this.ReleaseKey(Keys.Space);
            }

            if (this.gameState == GameState.Play)
            {
                // update each game object
                foreach (GameObject gameObject in gameObjects)
                {
                    gameObject.Update(this, deltaT);
                }
            }

            // remove dead objects
            gameObjects.RemoveWhere(gameObject => !gameObject.IsAlive());
        }
        #endregion
    }
}
