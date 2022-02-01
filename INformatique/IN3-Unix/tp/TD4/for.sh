#!/bin/bash

if [ $# -ne 3 ]; then
    echo "Le nombre de parametre doit etre egal a trois"
    exit
fi

if [ $3 -le 0 ]; then
    echo "increment inferieur a 0"
    exit
fi

if $1 > $2; then
    x1=$2
    x2=$1
else
    x1=$1
    x2=$2
fi

echo -e "\nfor:"
for ((x=x1;x<=x2;x=x+$3));do
    y=$(( x*x ))
    echo $y
done

echo -e "\nrepeter jusqu'a:"
x=x1
until [ $x -gt $((x2+1)) ]; do
    y=$(( x*x ))
    echo $y
    x=$((x+$3))
done