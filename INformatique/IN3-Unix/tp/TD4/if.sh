#!/bin/bash

echo -e "Choix 1\nChoix 2\nChoix 3"
read

if [ $REPLY == 1 ]; then
    echo "Choix 1 choisie"
elif [ $REPLY == 2 ]; then
    echo "Choix 2 choisie"
elif [ $REPLY == 3 ]; then
    echo "Choix 3 choisie"
else
    echo "Vous avez tapé n'importe quoi !"
fi

while read line
do  
   for mot in $line; do 
        nombre='^[0-9]+$'
        if ! [[ $mot =~ $nombre ]] ; then
            continue
        fi
        if [ $mot -ge -10 ]; then
            echo "$mot"
        fi
    done
done < data.txt

