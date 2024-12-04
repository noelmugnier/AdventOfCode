package main

import "testing"

func TestParseContentDirectionsAsStrings(t *testing.T) {
	t.Run("should return rows as strings", func(t *testing.T) {
		data := `MMA
MSA
AMX`

		want := []string{"MMA", "MSA", "AMX"}

		got := parseContentDirectionsAsStrings(data)

		for i, v := range want {
			if v != got[i] {
				t.Errorf("Got %v want %v", got[i], v)
			}
		}
	})

	t.Run("should return columns as strings", func(t *testing.T) {
		data := `MMA
MSA
AMX`

		want := []string{"MMA", "MSA", "AMX", "MMA", "MSM", "AAX"}

		got := parseContentDirectionsAsStrings(data)

		for i, v := range want {
			if v != got[i] {
				t.Errorf("Got %v want %v", got[i], v)
			}
		}
	})

	t.Run("should return diagonals as strings", func(t *testing.T) {
		data := `MMA
MSA
AMX`

		want := []string{"MMA", "MSA", "AMX", "MMA", "MSM", "AAX", "A", "MM", "MSX", "MA", "A"}

		got := parseContentDirectionsAsStrings(data)

		for i, v := range want {
			if v != got[i] {
				t.Errorf("Got %v want %v", got[i], v)
			}
		}
	})

	t.Run("should return valid word occurrence count", func(t *testing.T) {
		data := `MMA
MSA
AMX`

		want := []string{"MMA", "MSA", "AMX", "MMA", "MSM", "AAX", "A", "MM", "MSX", "MA", "A", "M", "MM", "ASA", "MA", "X"}

		got := parseContentDirectionsAsStrings(data)

		for i, v := range want {
			if v != got[i] {
				t.Errorf("Got %s want %s", got[i], v)
			}
		}
	})
}