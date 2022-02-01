#!/bin/bash

countAll(){
    dossier=0;
    fichier=0;
    executable=0;
    for d in $(find / -type d -name "$1" 2>/dev/null) ; do
        for a in $(ls $d)/ ; do
            if [ -d "$d/$a" ]; then
                ((dossier=dossier+1))
            elif [ -x "$d/$a" ]; then
                ((executable=executable+1))
            elif [ -f "$d/$a" ]; then
                ((fichier=fichier+1))
            elif [ -e "$d/$a" ]; then
                ((fichier=fichier+1))
            fi
        done
    done
    echo "Ce dossier possède $dossier sous répertoires, $fichier fichiers et $executable executables"
}

if [ $# -ne 1 ]; then
    echo -e "Veuillez saisir le nom du répertoire"
    read reper
    countAll $reper
else
    countAll $1
fi