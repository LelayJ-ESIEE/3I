#!/bin/bash

echo -e "nombre"
read nombre
resultat=$nombre

for ((x=1;x<nombre;x=x+1));do
    resultat=$(($resultat * $nombre))
done

echo $resultat