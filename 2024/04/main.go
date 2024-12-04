package main

import (
	"fmt"
	"os"
)

func main() {
	bytes, err := os.ReadFile("input.txt")

	if err != nil {
		panic(err)
	}

	data := parseContentDirectionsAsStrings(string(bytes))
	occurrences := countWordOccurrences(data)
	fmt.Printf("part1: %d\n", occurrences)

	occurrences = countWordCrossOccurrences(string(bytes))
	fmt.Printf("part2: %d\n", occurrences)
}