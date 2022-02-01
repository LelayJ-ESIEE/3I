#!/bin/bash
let f=0
let d=0
for i in *; do
	if [ -d $i ]; then
		let d=d+1
	elif [ -f $i ]; then
		let f=f+1
	fi
done
echo "There are $f files and $d directories"
