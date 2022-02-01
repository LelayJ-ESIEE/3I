#!/bin/bash

echo "Menu :"
echo "    Option 1"
echo "    Option 2"
echo
read Option
case $Option in
	"Option 1")echo "Option 1 choisie";;
	"Option 2")echo "Option 2 choisie";;
	*)echo "Option invalide choisie";;
esac
