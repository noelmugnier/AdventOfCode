package main

import (
	"fmt"
	"os"
)

func main() {
	data, err := load_input("input.txt")
	if err != nil {
		panic(err)
	}

	result, err := process01(data)
	if err != nil {
		panic(err)
	}

	fmt.Printf("Part 1: %d\n", result)

	result, err = process02(data)
	if err != nil {
		panic(err)
	}

	fmt.Printf("Part 2: %d\n", result)
}

func load_input(filename string) (string, error) {
	content, err := os.ReadFile(filename)

	if err != nil {
		return "", err
	}

	return string(content), nil
}