#!/bin/bash

if ! [ -e "$1" ]; then
    echo "ce n'est pas un fichier"
else
    while read line
    do  
        for mot in $line; do 
            if grep $mot /etc/passwd >/dev/null; then
                echo $line
            fi
            break
        done
    done < "$1"
fi