/* int factorielle_iterative (int n)
 * calcule la factorielle de n
 * Principe : accumulation des produits des n premiers nombres
 * arguments : n entier positif
 * retour : factorielle de n si n >=0
                      1 si n est negatif
 * JCG ecrit le 22/03/2001 modif le 14/04/2013
 */
int factorielle_iterative ( int n ) {
    int i, p = 1;
    for(i = 1; i <= n; ++i )
        p *= i;
    return p;
}

/* ******************************************************************* */

/* int factorielle_recursive (int n)
 * calcule la factorielle de n
 * Principe : F(n)=1 si n=0 , F(n)=n*F(n -1) si n >0
 * arguments : n entier positif
 * retour : factorielle de n si n >=0
                  1 si n est negatif
 * JCG ecrit le 22/03/2001 modif le 14/04/2013
 */
int factorielle_recursive ( int n ) {
    if(n <= 0)
        return 1;
    else
        return n * factorielle_recursive(n-1) ;
}

/* ********************************************************************* */

#include <stdio.h>
int main ( void ) {
    int n ;
    do {
        printf ("Entrez un nombre entier (0 pour terminer) : ") ;
        scanf ("%d", &n) ;
        printf ("factorielle_iterative (%2d) = %15d \n", n, factorielle_iterative(n));
        printf ("factorielle_recursive (%2d) = %15d \n", n, factorielle_recursive(n));
    }while ( n != 0) ;
    return 0;
}
