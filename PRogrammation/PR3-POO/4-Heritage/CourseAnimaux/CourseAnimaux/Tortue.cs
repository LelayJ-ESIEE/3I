using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAnimaux
{
    class Tortue : Animal
    {
        public int EpaisseurCarapasse { get; private set; }

        public Tortue(string pSurnom, int pAge, int pPosition, int pEpaisseurCarapasse) : base(pSurnom, pAge, pPosition)
        {
            this.EpaisseurCarapasse = pEpaisseurCarapasse;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + this.EpaisseurCarapasse;
        }

        public override void Avancer()
        {
            this.Position += 6;
        }
    }
}
