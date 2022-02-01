#!/bin/bash

echo -e "rentrer une note"
read

nombre='^[0-9]+$'
if ! [[ $REPLY =~ $nombre ]] || [ $REPLY -lt 0 ] || [ $REPLY -gt 20 ]; then
    echo "Vous avez tapé n'importe quoi !"
elif [ $REPLY -gt 16 ] && [ $REPLY -le 20 ]; then
    echo "très bien"
elif [ $REPLY -gt 14 ] && [ $REPLY -le 16 ]; then
    echo "bien"
elif [ $REPLY -gt 12 ] && [ $REPLY -le 14 ]; then
    echo "assez bien"
elif [ $REPLY -gt 10 ] && [ $REPLY -le 12 ]; then
    echo "moyen"
elif [ $REPLY -ge 0 ] && [ $REPLY -le 10 ]; then
    echo "insuffisant"  
fi