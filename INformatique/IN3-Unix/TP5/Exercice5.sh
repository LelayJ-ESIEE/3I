#!/bin/bash

saisie(){
    read i
    while [ "$i" != '1' ] && [ "$i" != '2' ] && [ "$i" != 'q' ]; do
        echo "Vous avez tapé n'importe quoi !"
        read i
    done
    if [ "$i" == 'q' ]; then
        return 0; 
    fi
    return $i
}

verifier(){
    echo -e "Veuillez saisir le nom de l'utilisateur\n"
    read user
    if id "$1" >/dev/null 2>&1; then
        echo "L'utilisateur $1 existe !"
    else
        echo "L'utilisateur n'existe pas!"
    fi
}

commande=1

while [ $commande -ne 0 ]; do

    echo -e "\n1 - Vérifier l'existence d'un utilisateur\n
    2 - Connaître l'UID d'un utilisateur\n
    q - Quitter\n"

    saisie
    commande=$?

    case $commande in
        1) verifier $user;;
        2) echo -e "Veuillez saisir le nom de l'utilisateur\n"
            read user
            id -u $user;;
        0) echo "Quitte !";;
    esac
done