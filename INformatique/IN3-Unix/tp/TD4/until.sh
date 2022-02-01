#!/bin/bash

a=0
until [ $a == "fin" ]; do
    read a
    $a
done