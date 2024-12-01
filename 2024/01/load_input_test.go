package main

import (
	"testing"
)

func TestLoadInput(t *testing.T) {
	t.Run("should load the input as two slices", func(t *testing.T) {
		first, second, err := loadInput("test_load_input.txt")
		if err != nil {
			t.Errorf("unexpected error: %s", err)
		}

		if len(first) != len(second) {
			t.Errorf("first and second slices should have the same length")
		}

		if len(first) != 3 {
			t.Errorf("first slice should have 3 elements")
		}

		if len(second) != 3 {
			t.Errorf("second slice should have 3 elements")
		}
	})
}
