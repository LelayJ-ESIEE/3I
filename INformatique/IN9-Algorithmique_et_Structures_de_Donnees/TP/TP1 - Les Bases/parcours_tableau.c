#include <stdio.h>
#include <math.h>

/* la reponse a la question precedente */
#define ZERO 1e-100
#define EPSILON 1e-10

/* inclure <math.h> et compiler avec gcc -lm */
int proche ( double a, double b ) {
    // Votre code de l ' exercice 2
}

double moyenne ( double t[], int n ) {
    /* calcule la moyenne des n premiers elements du tableau t */
    /* --------------
    * a faire
    * --------------
    */
    return 0.0;
}

double moyenne_positifs ( double t[]) {
    /* calcule la moyenne des elements du tableau t jusqu 'a rencontrer un
    element negatif et -1.0 si le premier element est deja negatif */
    /* --------------
    * a faire
    * --------------
    */
    return 0.0;
}

double test_moyenne () {
    double v[] = {1.0, 2.0, 3.0, 4.0, 5.0, 6.0, -1.0};
    double d, attendu ;
    attendu = 1;

    /* test moyenne */
    if (!proche (( d = moyenne (v, 1) ), attendu ) ) {
        printf (" Pb moyenne. Attendu : %f Obtenu :%f \n ", attendu, d ) ;
    }
    attendu = 2.0;
    if (!proche (( d = moyenne (v, 3) ), attendu ) ) {
        printf (" Pb moyenne. Attendu : %f Obtenu :%f \n ", attendu, d ) ;
    }
    attendu = 3.5;
    if (!proche (( d = moyenne (v, 6) ), attendu ) ) {
        printf (" Pb moyenne. Attendu : %f Obtenu :%f \n ", attendu, d ) ;
    }
    /* test moyenne positifs */
    attendu = 3.5;
    if (!proche (( d = moyenne_positifs ( v ) ), attendu ) ) {
        printf (" Pb moyenne_positifs . Attendu : %f Obtenu :%f \n ", attendu, d ) ;
    }
    attendu = 5.0;
    if (!proche (( d = moyenne_positifs ( v + 3) ), attendu ) ) {
        printf (" Pb moyenne_positifs . Attendu : %f Obtenu :%f \n ", attendu, d ) ;
    }
    attendu = -1.0;
    if (!proche ( d = moyenne_positifs (v + 6), -1.0) ) {
        printf (" Pb moyenne_positifs . Attendu : %f Obtenu :%f \n ", attendu, d ) ;
    }
}

int main () {
    test_moyenne () ;
    return 0;
}
