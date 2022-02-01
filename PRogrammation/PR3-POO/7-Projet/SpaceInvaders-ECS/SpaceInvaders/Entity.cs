using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities
{
    class Entity
    {
        private Dictionary<Type,Component> Components
        {
            get;
        }

        public Entity()
        {
            this.Components = new Dictionary<Type, Component>();
        }

        public Component GetComponent(Type componentType)
        {
            return Components[componentType];
        }

        public void AddComponent(Component component)
        {
            this.Components[component.GetType()] = component;
        }

        public void RemoveComponent(Type componentType)
        {
            if (this.HasComponent(componentType))
            {
                this.Components.Remove(componentType);
            }
        }

        public bool HasComponent(Type componentType)
        {
            return Components.ContainsKey(componentType);
        }

    }
}
