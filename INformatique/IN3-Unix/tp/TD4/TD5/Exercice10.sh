#!/bin/bash

convertBinary(){
    re='^[0-9]+$'
    result=0
    cpt=8
    mask=128
    array=()
    if [ $1 -lt $mask && $1 =~ $re ]; then
        while [ $cpt -ne 0 ]; do
            ((result=$1&mask))
            if [ $result -ne 0 ]; then
                array+=(1)
            else
                array+=(0)
            fi
            ((cpt=cpt-1))
            ((mask=mask>>1))
        done
        var=""
        for value in "${array[@]}"
        do
            var+=$value
        done
        echo $var
    else
        echo "La valeur est supérieure à 8 bits"
    fi
}

if [ $# -ne 1 ]; then
    echo -e "Veuillez saisir une valeur décimale"
    read n
    convertBinary $n
else
    convertBinary $1
fi