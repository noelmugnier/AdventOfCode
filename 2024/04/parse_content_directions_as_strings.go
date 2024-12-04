package main

import (
	"bufio"
	"strings"
)

func parseContentDirectionsAsStrings(data string) []string {
	result := make([]string, 0)

	rowsOfChars := parseContentAsCharArray(data)

	result = append(result, getHorizontalStrings(rowsOfChars)...)
	result = append(result, getVerticalStrings(rowsOfChars)...)
	result = append(result, getFirstDiagonalStrings(rowsOfChars)...)
	result = append(result, getSecondDiagonalStrings(rowsOfChars)...)

	return result
}

func getSecondDiagonalStrings(rowsOfChars [][]rune) []string {
	result := make([]string, 0)
	dataSize := len(rowsOfChars)
	count := dataSize - 1
	x := 0
	y := 0
	loop := 0
	for currentIteration := 0; currentIteration < dataSize*2-1; currentIteration++ {
		var strBuilder strings.Builder

		if currentIteration < dataSize {
			loop = currentIteration + 1
			x = currentIteration
			y = 0
		} else {
			loop--
			x = count
			y = currentIteration - count
		}

		for i := 0; i < loop; i++ {
			strBuilder.WriteRune(rowsOfChars[x-i][y+i])
		}

		result = append(result, strBuilder.String())
	}
	return result
}

func getFirstDiagonalStrings(rowsOfChars [][]rune) []string {
	result := make([]string, 0)
	dataSize := len(rowsOfChars)
	count := dataSize - 1
	x := 0
	y := 0
	loop := 0

	for currentIteration := 0; currentIteration < dataSize*2-1; currentIteration++ {
		var strBuilder strings.Builder

		if currentIteration < dataSize {
			loop = currentIteration + 1
			x = count - currentIteration
			y = 0
		} else {
			loop--
			x = 0
			y = currentIteration - count
		}

		for i := 0; i < loop; i++ {
			strBuilder.WriteRune(rowsOfChars[x+i][y+i])
		}

		result = append(result, strBuilder.String())
	}
	return result
}

func getVerticalStrings(rowsOfChars [][]rune) []string {
	result := make([]string, 0)
	dataSize := len(rowsOfChars)
	for i := 0; i < dataSize; i++ {
		var strBuilder strings.Builder
		for j := 0; j < dataSize; j++ {
			strBuilder.WriteRune(rowsOfChars[j][i])
		}

		result = append(result, strBuilder.String())
	}
	return result
}

func getHorizontalStrings(rowsOfChars [][]rune) []string {
	result := make([]string, 0)
	for _, rowChars := range rowsOfChars {
		var strBuilder strings.Builder
		for _, char := range rowChars {
			strBuilder.WriteRune(char)
		}

		result = append(result, strBuilder.String())
	}
	return result
}

func parseContentAsCharArray(data string) [][]rune {
	result := make([][]rune, 0)

	reader := strings.NewReader(data)
	scanner := bufio.NewScanner(reader)

	for scanner.Scan() {
		result = append(result, []rune(scanner.Text()))
	}

	return result
}