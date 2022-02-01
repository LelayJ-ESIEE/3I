#!/bin/bash
let x=$1
until [ $x == $2 ]
	do
	let r=$x*$x
	echo $r
	let x=$x+$3
done
