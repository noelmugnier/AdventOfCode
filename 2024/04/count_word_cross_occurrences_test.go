package main

import "testing"

func TestCountWordCrossOccurrences(t *testing.T) {
	t.Run("should return valid word occurrence count", func(t *testing.T) {
		data := `MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX`

		want := 9
		got := countWordCrossOccurrences(data)

		if got != want {
			t.Errorf("Got %d want %d", got, want)
		}
	})
}