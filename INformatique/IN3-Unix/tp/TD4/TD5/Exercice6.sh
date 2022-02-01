#!/bin/bash

calc(){
    re='^[0-9]+$'
    if ! [[ $1 =~ $re ]] || ! [[ $3 =~ $re ]]; then
        echo "Les opérateurs ne sont pas des nombres !"
    elif [ $3 -eq 0 ] && [ $2 == '/' ]; then
        echo "Division par 0 impossible"
    else
        case $2 in
            "*") echo $(( $1*$3 ));;
            "+") echo $(( $1+$3 ));;
            "-") echo $(( $1-$3 ));;
            "/") echo $(( $1/$3 ));;
            *) echo "L'opérateur n'est pas bon!";;
        esac
    fi
}

if [ $# -ne 3 ]; then
    echo -e "\nTaper un chiffre: "
    read x1;
    echo -e "\nTaper un opérateur: "
    read op;
    echo -e "\nTaper un autre chiffre: "
    read x2;
    calc $x1 $op $x2
    
else
    calc $1 $2 $3
fi