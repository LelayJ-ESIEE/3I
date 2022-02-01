#!/bin/bash

echo "Menu :"
echo "    Option 1"
echo "    Option 2"
echo
read Option
if [ "$Option" == "Option 1" ]
	then
		echo "Option 1 choisie"
	elif [ "$Option" == "Option 2" ]; then
		echo "Option 2 choisie"
	else
		echo "Option invalide choisie"
fi
