using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLapin
{
    class Lapin
    {
        String surnom;
        int age;

        static int nombreDeLapins = 0;
        public string Surnom
        {
            get
            {
                return this.surnom;
            }
            set
            {
                this.surnom = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value >= 0)
                    this.age = value;
            }
        }
        public int Position { get; set; }

        public Lapin(String surnom, int age)
        {
            this.Surnom = surnom;
            this.Age = age;
            this.Position = 0;
            Lapin.nombreDeLapins += 1;
        }

        public static int NombreDeLapin()
        {
            return Lapin.nombreDeLapins;
        }

        public void Avancer()
        {
            Random randObj = new Random();
            this.Position += randObj.Next(6);
        }
    }
}
