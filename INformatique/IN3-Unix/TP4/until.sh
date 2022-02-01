#!/bin/bash

read com
c=""

until [ ! -z "$c" ]; do
	$com
	read c
done
