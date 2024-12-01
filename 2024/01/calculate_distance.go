package main

import (
	"math"
	"sort"
)

func calculateDistance01(firstValues []int, secondValues []int) (int, error) {
	distance := 0

	sort.Ints(firstValues)
	sort.Ints(secondValues)

	for index, firstValue := range firstValues {
		secondValue := secondValues[index]
		distance += int(math.Abs(float64(firstValue - secondValue)))
	}

	return distance, nil
}

func calculateDistance02(firstValues []int, secondValues []int) (int, error) {
	distance := 0

	sort.Ints(firstValues)
	sort.Ints(secondValues)

	secondValuesCount := make(map[int]int, 0)
	for _, secondValue := range secondValues {
		secondValuesCount[secondValue]++
	}

	for _, firstValue := range firstValues {
		if firstValueOccurenceCount, ok := secondValuesCount[firstValue]; ok {
			distance += firstValue * firstValueOccurenceCount
		}
	}

	return distance, nil
}

