#!/bin/bash

for i in $@
	do
	if [ -e $i ]
		then
			if [ -d $i ]
				then
					echo "$i est un dossier"
				elif [ -f $i ]; then
					echo "$i est un fichier"
				else
					echo "$i : Qui suis-je ? Ou vais-je ? Dans quelle etagere ?"
			fi
		else
			echo "$i n'existe pas"
	fi
done
