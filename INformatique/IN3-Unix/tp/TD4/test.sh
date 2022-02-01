#!/bin/bash

for i in "$@"; do
    if [ -d "$i" ]; then
        echo "$i est un dossier"
    elif [ -e "$i" ]; then
        echo "$i est un fichier qui existe"
    elif [ -f "$i" ]; then
        echo "$i est un fichier standart qui existe"
    else
       echo "$i n'existe pas"
    fi
done

echo -e "\nLes dossiers:"
for i in *; do
    if [ -d "$i" ]; then
        echo "$i"
    fi
done

echo -e "\nLes fichiers:"
for i in *; do
    if [ -e "$i" ]; then
        echo "$i"
    fi
done

j=$(find -maxdepth 1 -type d | wc -l)
i=$(find -maxdepth 1 -type f | wc -l)
echo -e "\nNombre de dossier: $j"
echo -e "\nNombre de fichiers: $i"