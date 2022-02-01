#!/bin/bash

factorielle(){
    re='^[0-9]+$'
    if [[ $1 -le 0 ]] || ! [[ $1 =~ $re ]]; then
        echo "0";
    else
        cpt=1;
        result=1;
        while [ $1 -ge $cpt ]; do
            ((result=result*cpt));
            ((cpt=cpt+1));
        done
        echo $result
    fi
}

if [ $# -ne 1 ]; then
    echo -e "Veuillez saisir le n factiorielle"
    read n
    factorielle $n
else
    factorielle $1
fi