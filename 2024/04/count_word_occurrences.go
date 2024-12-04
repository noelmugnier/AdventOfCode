package main

import "regexp"

func countWordOccurrences(data []string) int {
	reg1 := regexp.MustCompile(`XMAS`)
	occurrencesCount := 0
	for _, row := range data {
		matches := reg1.FindAllStringSubmatch(row, -1)
		for _, match := range matches {
			if match[0] != "" {
				occurrencesCount++
			}
		}
	}
	reg2 := regexp.MustCompile(`SAMX`)
	for _, row := range data {
		matches := reg2.FindAllStringSubmatch(row, -1)
		for _, match := range matches {
			if match[0] != "" {
				occurrencesCount++
			}
		}
	}
	return occurrencesCount
}