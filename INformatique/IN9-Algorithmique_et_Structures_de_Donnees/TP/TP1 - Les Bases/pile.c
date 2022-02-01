
#define TMAX 10

typedef struct struct_t_pile {
    int donnees[TMAX];
    int sommet;
};

typedef struct struct_t_pile t_pile;


void init_pile ( t_pile * pp ) {
    pp->sommet = 0;
}

int est_vide_pile ( t_pile * pp ) {
    return pp->sommet == 0;
}

void empile ( t_pile * pp , int x ) {
    pp->contenu[pp->sommet] = x ;
    ++ pp->sommet ;
    /* pour les voltigeurs :
    pp->contenu[pp->sommet ++] = x;
    */
}

int depile ( t_pile * pp ) {
    --pp->sommet ;
    return pp->contenu[pp->sommet];
    /* pour les voltigeurs :
    return pp->contenu[--pp->sommet];;
    */
}

int lit_sommet_pile ( t_pile * pp ) {
    return pp->contenu[pp->sommet-1];
}
