#!/bin/bash

echo -e "Choix 1\nChoix 2\nChoix 3"
read

case $REPLY in
    1) echo "Choix 1 choisie";;
    2) echo "Choix 2 choisie";;
    3) echo "Choix 3 choisie";;
    *) echo "Vous avez tapé n'importe quoi !";;
esac