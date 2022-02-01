#!/bin/bash

chps=$(cut -f2 data.txt)

for i in $chps
	do
	if [ $i -gt 10 ]
		then
			echo $i
	fi
done
