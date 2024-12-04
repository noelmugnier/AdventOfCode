package main

func countWordCrossOccurrences(data string) int {
	rowsOfChars := parseContentAsCharArray(data)

	occurrences := 0
	dataSize := len(rowsOfChars)

	for i := 1; i < dataSize-1; i++ {
		for j := 1; j < dataSize-1; j++ {
			if rowsOfChars[i][j] != 'A' {
				continue
			}

			tl := rowsOfChars[i-1][j-1]
			br := rowsOfChars[i+1][j+1]

			word := string([]rune{tl, 'A', br})
			if word != "MAS" && word != "SAM" {
				continue
			}

			bl := rowsOfChars[i+1][j-1]
			tr := rowsOfChars[i-1][j+1]
			word = string([]rune{bl, 'A', tr})

			if word != "MAS" && word != "SAM" {
				continue
			}

			occurrences++
		}
	}

	return occurrences
}