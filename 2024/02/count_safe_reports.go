package main

import (
	"math"
)

func countSafeReports01(reports [][]int) int {
	safeReportsCount := 0
	for _, report := range reports {
		reportIsValid := true
		isIncreasing := isIncreasing(report)
		for currentLevelIndex := 0; currentLevelIndex < len(report)-1; currentLevelIndex++ {
			reportIsValid = reportLevelIsSafe(report, currentLevelIndex, currentLevelIndex+1, isIncreasing)
			if !reportIsValid {
				break
			}
		}

		if reportIsValid {
			safeReportsCount++
		}
	}

	return safeReportsCount
}

func countSafeReports02(reports [][]int) int {
	safeReportsCount := 0
	for _, report := range reports {
		reportIsValid := true
		isIncreasing := isIncreasing(report)

		invalidLevelSkipped := 0
		for currentLevelIndex := 0; currentLevelIndex < len(report)-1; currentLevelIndex++ {
			reportIsValid = reportIsValid && reportLevelIsSafe(report, currentLevelIndex, currentLevelIndex+1, isIncreasing)

			if !reportIsValid && currentLevelIndex == 0 {
				reportIsValid = reportLevelIsSafe(report, currentLevelIndex+1, currentLevelIndex+2, isIncreasing)
				if reportIsValid {
					invalidLevelSkipped++
				}
			}

			if !reportIsValid && currentLevelIndex < len(report)-2 {
				reportIsValid = reportLevelIsSafe(report, currentLevelIndex, currentLevelIndex+2, isIncreasing)
				if reportIsValid {
					invalidLevelSkipped++
				}
			}

			//if !reportIsValid && currentLevelIndex == len(report)-2 && invalidLevelSkipped < 1 {
			//reportIsValid = true
			//}
		}

		if reportIsValid && invalidLevelSkipped < 2 {
			safeReportsCount++
		}
	}

	return safeReportsCount
}

func isIncreasing(report []int) bool {
	isIncreasing := false

	i := 1
	for {
		if len(report)-i < 0 {
			break
		}

		if report[0] != report[len(report)-i] {
			isIncreasing = report[0] < report[len(report)-i]
			break
		}

		i++
	}

	return isIncreasing
}

func reportLevelIsSafe(report []int, currentLevelIndex int, nextLevelIndex int, isIncreasing bool) bool {
	diff := report[currentLevelIndex] - report[nextLevelIndex]

	if !diffIsValid(diff) {
		return false
	}

	if isIncreasing && diff > 0 {
		return false
	}

	if !isIncreasing && diff < 0 {
		return false
	}

	return true
}

func diffIsValid(diff int) bool {
	absDiff := math.Abs(float64(diff))
	return absDiff <= 3 && absDiff >= 1
}