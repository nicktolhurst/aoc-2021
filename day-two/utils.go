package main

import (
	"strconv"
)

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func toInt(s string) int {
	result, err := strconv.Atoi(s)
	check(err)
	return result
}
