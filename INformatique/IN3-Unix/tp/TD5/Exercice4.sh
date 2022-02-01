#!/bin/bash

appreciation(){
    nombre='^[0-9]+$'
    if ! [[ "$1" =~ $nombre ]] || [ "$1" -lt 0 ] || [ "$1" -gt 20 ]; then
        echo "Vous avez tapé n'importe quoi !"
    elif [ "$1" -gt 16 ] && [ "$1" -le 20 ]; then
        echo "très bien"
    elif [ "$1" -gt 14 ] && [ "$1" -le 16 ]; then
        echo "bien"
    elif [ "$1" -gt 12 ] && [ "$1" -le 14 ]; then
        echo "assez bien"
    elif [ "$1" -gt 10 ] && [ "$1" -le 12 ]; then
        echo "moyen"
    elif [ "$1" -ge 0 ] && [ "$1" -le 10 ]; then
        echo "insuffisant"  
    fi
}

if [ $# -ne 1 ]; then
    echo "pas d'argument ou trop d'argument."
    echo "Note de l'élève:"
    read
    appreciation $REPLY
else
    appreciation $1
fi