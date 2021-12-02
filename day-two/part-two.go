package main

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
)

func main_two() {
	file, err := os.Open("input")
	check(err)
	defer file.Close()

	var dat []string

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		dat = append(dat, scanner.Text())
	}

	xpos := 0
	zpos := 0
	aim := 0

	fmt.Print(len(dat))

	for i := 0; i < len(dat); i++ {

		fwd, _ := regexp.Compile("forward")
		up, _ := regexp.Compile("up")
		dwn, _ := regexp.Compile("down")
		num, _ := regexp.Compile(`\d+`)

		switch {
		case fwd.MatchString(dat[i]):
			val := toInt(num.FindString(dat[i]))

			xpos += val

			if aim > 0 {
				zpos += val * aim
			}

		case up.MatchString(dat[i]):
			aim -= toInt(num.FindString(dat[i]))

		case dwn.MatchString(dat[i]):
			aim += toInt(num.FindString(dat[i]))

		default:
			fmt.Println("It doesn't match")
		}
	}

	fmt.Printf("Answer: %d", xpos*zpos)
}
