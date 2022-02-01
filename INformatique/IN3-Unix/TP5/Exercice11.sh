#!/bin/bash

moyenne=0
nom=""
nombre='^[0-9]+$'
if ! [ -e "$1" ]; then
    echo "ce n'est pas un fichier"
else
    while read line
    do  
        for mot in $line; do 
            if [[ "$mot" =~ $nombre ]]; then
                moyenne=$((moyenne + mot))
            else
                nom=$mot
            fi
        done
        echo "$nom : $((moyenne / 3))" | bc -q
        moyenne=0
    done < "$1"
fi