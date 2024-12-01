package main

import "testing"

func TestCalculateDistance(t *testing.T) {
	t.Run("should return result of part 1", func(t *testing.T) {
		first := []int{3, 4, 2, 1, 3, 3}
		second := []int{4, 3, 5, 3, 9, 3}

		want := 11

		got, err := calculateDistance01(first, second)
		if err != nil {
			t.Errorf("unexpected error: %s", err)
		}

		if got != want {
			t.Errorf("got %d, want %d", got, want)
		}
	})

	t.Run("should return result of part 2", func(t *testing.T) {
		first := []int{3, 4, 2, 1, 3, 3}
		second := []int{4, 3, 5, 3, 9, 3}

		want := 31

		got, err := calculateDistance02(first, second)
		if err != nil {
			t.Errorf("unexpected error: %s", err)
		}

		if got != want {
			t.Errorf("got %d, want %d", got, want)
		}
	})
}

