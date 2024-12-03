package main

import (
	"regexp"
	"strconv"
)

var regEx1 = regexp.MustCompile("mul\\((\\d{1,3}),(\\d{1,3})\\)")

func process01(data string) (int, error) {
	matches := regEx1.FindAllStringSubmatch(data, -1)

	result := 0
	for _, match := range matches {
		first, _ := strconv.Atoi(match[1])
		second, _ := strconv.Atoi(match[2])
		result += first * second
	}

	return result, nil
}

var regEx2 = regexp.MustCompile("mul\\((\\d{1,3}),(\\d{1,3})\\)|(do\\(\\))|(don't\\(\\))")

func process02(data string) (int, error) {
	matches := regEx2.FindAllStringSubmatch(data, -1)

	result := 0
	skipMultiplication := false
	for _, match := range matches {
		if match[3] != "" {
			skipMultiplication = false
		}

		if match[4] != "" {
			skipMultiplication = true
		}

		if skipMultiplication {
			continue
		}

		if match[1] == "" || match[2] == "" {
			continue
		}

		first, _ := strconv.Atoi(match[1])
		second, _ := strconv.Atoi(match[2])
		result += first * second
	}
	return result, nil
}