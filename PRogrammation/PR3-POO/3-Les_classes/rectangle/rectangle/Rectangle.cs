using System;
using System.Collections.Generic;
using System.Text;

namespace rectangle
{
    class Rectangle
    {
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public int[] Position { get; set; }

        public Rectangle(int pLargeur, int pHauteur, int[] pPosition)
        {
            this.Largeur = pLargeur;
            this.Hauteur = pHauteur;
            this.Position = pPosition;
        }
        public Rectangle( Rectangle r) : this(r.Largeur, r.Hauteur, r.Position)
        { }

        public Rectangle() : this(10, 10, new int[] { 0, 0 })
        {}

        public int Aire()
        {
            return this.Largeur * this.Hauteur;
        }

        public void DoublerTaille()
        {
            this.Largeur *= 2;
            this.Hauteur *= 2;
        }

        public bool TestePlusPetit(Rectangle r)
        {
            return (r.Aire() < this.Aire());
        }
    }
}
