package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	data, err := readInput()
	if err != nil {
		panic(err)
	}

	fmt.Printf("part1: %d\n", countSafeReports01(data))
	fmt.Printf("part2: %d\n", countSafeReports02(data))
}

func readInput() ([][]int, error) {
	file, err := os.Open("input.txt")
	defer file.Close()

	if err != nil {
		return nil, err
	}

	var data [][]int
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := scanner.Text()
		if line == "" {
			continue
		}

		numbersAsString := strings.Split(line, " ")
		numbers := make([]int, len(numbersAsString))
		for i := range numbersAsString {
			n, err := strconv.Atoi(numbersAsString[i])
			if err != nil {
				return nil, err
			}

			numbers[i] = n
		}

		data = append(data, numbers)
	}
	return data, nil
}