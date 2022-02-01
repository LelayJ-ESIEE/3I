using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Nodes
{
    class RenderNode : Node
    {
        public PositionComponent Position;
        public SpriteComponent Sprite;

        public RenderNode(PositionComponent position, SpriteComponent sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
        }
    }
}
