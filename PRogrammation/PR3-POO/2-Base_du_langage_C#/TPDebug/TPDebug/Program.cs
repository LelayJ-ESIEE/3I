using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDebug
{
    class Program
    {

        //////////////////////////////////////////////////////
        //													//
        //               TP DEBOGAGE                        //
        //													//
        //////////////////////////////////////////////////////

        //		 F5  : RUN (lance l'execution jusqu'au prochain point d'arret
        // SHIFT F5  : STOP DEBUGGING (arret du debogage et du programme)
        //       F9  : BREAKPOINT (active un point d'arret sur la ligne courante)
        //		 F10 : STEP OVER (execute sans rentrer dans la fonction)
        // CTRL+ F10 : RUN TO CURSOR (lance le programme jusqu'a cet endroit)
        //		 F11 : STEP INTO (execute et rentre dans la fonction)
        // SHIFT+F11 : STEP OUT  (remonte a la fonction appelante)

        // pour commencer le TP, tappez F10

        static int Incr(int k)
        {                   // arrivée dans la fonction F10 ou F11 pour continuer, c'est équivalent
            int u = k + 1;  // F10/F11
            return u;       // F10/F11 remarquez que la liste des variables locales a changé, il n'y a plus que "u" et "k"
        }                   // F10/F11 c'est fini on remonte

        static int Inc1(int k)
        {                   // F10
            int u = k + 1;  // F10
            return u;       // F10
        }                   // F10 // on remonte

        static int Inc2(int k)
        {                   // F10
            int u = k + 1;  // F10
            return u;       // F10
        }                   // F10 // on remonte

        static void Test()
        {                                   // F10
            for (int i = 0; i < 10; i++)    // F10
            {
                if (i + 5 - 3 + 2 - 4 == 7)       // F10 -- on repart dans la boucle for
                                                  // j'aurais aimé connaitre cette valeur etrange
                                                  // i+5-3+2-4, je peux demander une evalutation à
                                                  // la volée en plaçant la souris au dessus:
                                                  // essayez de placer la souris au dessus de chacun 
                                                  // des opérateur + - + - == : que se passe-t-il ?

                    i += 7;                 // si on arrive ici la condition est vraie
            }
        }

        static void Test2()
        {                                       // F10
            for (int i = 0; i < 1000; i++)      // F10
            {
                if (i % 3 == 0)                 // F10
                    i += 4;                     // F10
            }                                   // on va jamais ressortir, c'est trop long à deboguer
                                                // ce tp est affreux, il nous faut un café...

            // solution magique !!! si F11 nous permet de nous introduire a l'intérieur d'un fonction
            // SHIFT F11 permet d'en ressortir (ouf !!!!) et de remonter a la fonction appelante
        }

        static void Test35()
        {               //F10
            int u = 1;  //F10
            u++;        //F10
            u++;        //F10
            u++;        //F10
        }

        static void Test34() { Test35(); }  //F11
        static void Test33() { Test34(); }  //F11
        static void Test32() { Test33(); }  //F11
        static void Test31() { Test32(); }  //F11
        static void Test30() { Test31(); }  //F11

        static void Test43(int u)
        {
            u++;    // F10
            u++;    // F10

            // a ce niveau on aimerait se rappeler quels ont été les appels de fonctions
            // qui nous ont amenés là : il suffit de regarder la Pile des appels
            // En cliquant dans la fenetre des appels sur les differents fonctions
            // test42, test41, test40 ...
            // vous pouvez remarquer que la fentre des variables locales est automatiquement
            // mise a jour pour contenir les valeurs des variables locales avant d'arriver 
            // jusqu'ici. Tous les appels précédents sont ainsi consultables
            // astuces : en positionnant le pointeur souris sur une variable, vous pouvez
            // faire afficher sa valeur

            u++;    // F10
            u++;    // F10
        }

        static void Test42(int u)
        {
            Test43(u + 1);  //F11
        }


        static void Test41(int u)
        {
            Test42(u + 1);  //F11
        }

        static void Test40(int u)
        {
            Test41(u + 1);  //F11
        }

 
        static void Main(string[] args)
        // F10 - lance le debug - arret à la premiere ligne du programme
        {               // F10 - passe a la ligne suivante
            int k = 0;  // F10
            k = 5;      // F10 - A cette ligne k vaut 0.
                        // Il s'agit du résultat de l'execution de la ligne précédente.
                        // Dans la fenetre des variables (ALT+4, onglet Auto ou Locals),
                        // la valeur de la variable est affichée. La couleur rouge signifie que
                        // la valeur vient de changer
            k = 0;      // F10 : idem
            k = 5;      // F10 : idem
            k = 5;      // F10 : couleur noire, le contenu a été mis a jour mais comme il est identique
                        //       l'interface considère qu'il n'y a pas eu de modification
            k = 0;      // F10 : couleur rouge
            k = Incr(k);    // F10 : l'appel de la fonction est exécutée sans debogage
                            // on passe directement a l'instruction d'après
            k = Incr(k);    // F10 : idem
            k = Incr(k);    // F10 : on aimerait bien voir ce qu'il se passe dans cette fonction qd meme !!
            k = Incr(k);    // F11 : allez hop on va dedans
                            // le debogueur ne passe pas encore à l'instruction suivante
                            // il attend une demande F10 ou F11 (appuyez)

            k = Inc2(Inc1(k));  // F11 on rentre dans inc1
                                // on revient ici après le debogage de inc1
                                // AVANT l'appel de inc2. Pour rentrer dans inc2 :
                                // F11 
                                // Pour finir, F10 ou F11

            k = Incr(k);    // F10
                            // supposons que je voulais deboguer cette foncion en appyant sur F11 
                            // cest trop tard !!! il faudrait recommencer du début :(
                            // trop long !!! Pour cela, on arrete le debogage : SHIFT-F5
                            // on positionne le curseur sur la ligne ou l'on veut recommencer
                            // et on relance tout jusqu'a cette ligne (RUN TO CURSOR : CTRL-F10) 

            k = 0;  // F10
            k = 0;  // F10
            k = 0;  // F10   En mode Debug, le compilateur garde toutes les instructions 
            k = 0;  // F10   même si elles sont inutiles...
            k = 0;  // F10

            Test();  // F11

            Test2(); // F11 

            Test30(); // F11

            Test30(); // F11
            Test30(); // F11
            Test30(); // F11 // idem

            // Nous allons tenter une autre méthode, allons directement à la fonction test35()
            // et dans le code insérons un breakpoint : F9 sur la ligne ou clique dans la marge gauche
            // Le breakpoint est matérialisé par un point rouge dans la marge.
            // Des que le programme passe sur ce point d'arret, le deboguage se remet en marche.

            Test30(); // F5 ou F10 
                      // si le breakpoint a marche vous devriez etre arreté dessus
                      // pour retirer le breakpoint F9 sur la ligne ou il est actif

            Test40(11); // F11
        }
    }
}
