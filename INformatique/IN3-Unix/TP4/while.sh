#!/bin/bash

a=0

while [ $a -ne 9 ]; do

    echo -e "\n1 Afficher la date (date)\n
    2 Afficher le nombre de personnes connectées (who)\n
    3 Afficher la liste des processus (ps)\n
    9 Quitter\n"

    read a

    case $a in
        1) date;;
        2) who -q;;
        3) ps;;
        9) echo "Quitte !";;
        *) echo "Vous avez tapé n'importe quoi !";;
    esac

done