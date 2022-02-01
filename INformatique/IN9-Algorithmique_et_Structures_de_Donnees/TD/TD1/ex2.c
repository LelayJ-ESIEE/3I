#include<stdlib.h>

// a)

typedef struct element
{
    int nombre;
    Element *suivant;
} Element;

typedef struct file
{
    Element *premier;
    Element *dernier;
    int size;
} File;

File* allocateFile()
{
    File* file = (File*) malloc(sizeof(File));
    file->premier = NULL;
    file->dernier = NULL;
    file->size = 0;
}

void enfiler(File *file, int nvNombre)
{
    Element *nouveau = malloc(sizeof(*nouveau));
    if (file == NULL || nouveau == NULL)
    {
        exit(EXIT_FAILURE);
    }

    nouveau->nombre = nvNombre;
    nouveau->suivant = NULL;

    if (file->premier != NULL) /* La file n'est pas vide */
    {
        /* On se positionne à la fin de la file */
        Element *elementActuel = file->dernier;
        elementActuel->suivant = nouveau;
        nouveau->suivant = file->premier;
    }
    else /* La file est vide, notre élément est le premier */
    {
        file->premier = nouveau;
        file->dernier = nouveau;
        nouveau->suivant = file->premier;
    }
    file->size += 1;
}

int defiler(File *file)
{
    if (file == NULL)
    {
        exit(EXIT_FAILURE);
    }

    int nombreDefile = 0;

    /* On vérifie s'il y a quelque chose à défiler */
    if (file->premier != NULL)
    {
        Element *elementDefile = file->premier;

        nombreDefile = elementDefile->nombre;
        file->premier = elementDefile->suivant;
        free(elementDefile);
    }
    file->dernier->suivant = file->premier;
    file->size -= 1;
    return nombreDefile;
}

typedef struct bufferC
{
    File* file;
    int size;
} BufferC;

