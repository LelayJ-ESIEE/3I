#!/bin/bash

select CHOIX in "Afficher la liste des utilisateurs connectés" "Afficher la liste des processus" "Afficher à l'utilisateur son nom, son UID, son GID, son TTY" "Quitter";do
    case $REPLY in
        1) who;;
        2) ps;;
        3) id -u && id -g && tty;;
        4) exit;;
        *) echo "Vous avez tapé n'importe quoi !";;
    esac
done