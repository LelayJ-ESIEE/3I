#!/bin/bash

while read line
do  
   for mot in $line; do 
        nombre='^[0-9]+$'
        if ! [[ $mot =~ $nombre ]] ; then
            continue
        fi
        if [ "$mot" -ge 10 ]; then
            echo "$line"
        fi
    done
done < FichierNote.txt