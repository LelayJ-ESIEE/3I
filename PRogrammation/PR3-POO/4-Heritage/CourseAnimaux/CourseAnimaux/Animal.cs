using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAnimaux
{
    abstract class Animal
    {
        public string Surnom { get; private set; }
        public int Age { get; private set; }
        public int Position { get; protected set; }

        public Animal(string pSurnom, int pAge, int pPosition)
        {
            this.Surnom = pSurnom;
            this.Age = pAge;
            this.Position = pPosition;
        }

        public override string ToString()
        {
            return (this.Surnom + ", " + this.Age + ", " + this.Position) ;
        }

        public abstract void Avancer();
    }
}
