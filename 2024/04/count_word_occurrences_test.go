package main

import "testing"

func TestCountWordOccurrences(t *testing.T) {
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

		runes := parseContentDirectionsAsStrings(data)

		want := 18

		got := countWordOccurrences(runes)

		if got != want {
			t.Errorf("Got %d want %d", got, want)
		}
	})
}