using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Nodes;

namespace SpaceInvaders.Systems
{
    abstract class System
    {
        /// <summary>
        /// Initialises the system
        /// </summary>
        public abstract void Start(List<Node> nodes);

        /// <summary>
        /// Updates the Nodes depending on time
        /// </summary>
        public abstract void Update(int time);

        /// <summary>
        /// Cleans-up the system
        /// </summary>
        public abstract void End();
    }
}
