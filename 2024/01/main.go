package main

import (
	"fmt"
)

func main() {
	first, second, err := loadInput("input.txt")
	if err != nil {
		panic(err)
	}

	distance, err := calculateDistance01(first, second)
	if err != nil {
		panic(err)
	}

	fmt.Printf("part1: %d\n", distance)

	distance, err = calculateDistance02(first, second)
	if err != nil {
		panic(err)
	}

	fmt.Printf("part2: %d\n", distance)
}

