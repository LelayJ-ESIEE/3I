using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAnimaux
{
    class Lapin : Animal
    {
        public string CouleurFourrure { get; private set; }

        public Lapin(string pSurnom, int pAge, int pPosition, string pCouleurFourrure) : base(pSurnom, pAge, pPosition)
        {
            this.CouleurFourrure = pCouleurFourrure;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + this.CouleurFourrure;
        }

        public override void Avancer()
        {
            Random randObj = new Random();
            this.Position += randObj.Next(10);
        }
    }
}
