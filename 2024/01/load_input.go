package main

import (
	"bufio"
	"os"
	"strconv"
	"strings"
)

func loadInput(filePath string) ([]int, []int, error) {
	firstElements := make([]int, 0)
	secondElements := make([]int, 0)

	file, err := os.OpenFile(filePath, os.O_RDONLY, os.ModePerm)
	defer file.Close()

	if err != nil {
		return nil, nil, err
	}

	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := scanner.Text()
		if line == "" {
			continue
		}

		numbers := strings.Split(line, "   ")

		firstNumber, err := strconv.ParseInt(numbers[0], 10, 32)
		if err != nil {
			return nil, nil, err
		}

		secondNumber, err := strconv.ParseInt(numbers[1], 10, 32)
		if err != nil {
			return nil, nil, err
		}

		firstElements = append(firstElements, int(firstNumber))
		secondElements = append(secondElements, int(secondNumber))
	}

	return firstElements, secondElements, nil
}
