package main

import (
	"testing"
)

func TestCountSafeReports(t *testing.T) {
	t.Run("part1 should return true when increase constantly", func(t *testing.T) {
		data := [][]int{
			{1, 2, 3, 4, 5},
		}

		want := 1
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part1 should return true when decrease constantly", func(t *testing.T) {
		data := [][]int{
			{5, 4, 3, 2, 1},
		}

		want := 1
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part1 should return true when increase constantly with more than one", func(t *testing.T) {
		data := [][]int{
			{1, 3, 5, 7, 9},
		}

		want := 1
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part1 should return false when step is more than 3", func(t *testing.T) {
		data := [][]int{
			{2, 6, 10, 14},
		}

		want := 0
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part1 should return false when step is less than 1", func(t *testing.T) {
		data := [][]int{
			{2, 6, 6, 14},
		}

		want := 0
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part1 should return false when step is increasing and decreasing", func(t *testing.T) {
		data := [][]int{
			{1, 3, 2, 4, 5},
		}

		want := 0
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part1 should return valid result", func(t *testing.T) {
		data := [][]int{
			{7, 6, 4, 2, 1},
			{1, 2, 7, 8, 9},
			{9, 7, 6, 2, 1},
			{1, 3, 2, 4, 5},
			{8, 6, 4, 4, 1},
			{1, 3, 6, 7, 9},
		}

		want := 2
		got := countSafeReports01(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part2 should return true when only one step change direction", func(t *testing.T) {
		data := [][]int{
			{1, 2, 3, 2, 5},
		}

		want := 1
		got := countSafeReports02(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part2 should return false when two or more step change direction", func(t *testing.T) {
		data := [][]int{
			{1, 2, 3, 2, 4, 2, 5, 6},
		}

		want := 0
		got := countSafeReports02(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})

	t.Run("part2 should return valid result", func(t *testing.T) {
		data := [][]int{
			{1, 2, 7, 8, 9},
			{9, 7, 6, 2, 1},
			//{7, 6, 4, 2, 1},
			//{1, 3, 2, 4, 5},
			//{8, 6, 4, 4, 1},
			//{1, 3, 6, 7, 9},
			//{1, 1, 2, 3, 4, 5},
			//{48, 46, 47, 49, 51, 54, 56},
			//{1, 2, 3, 4, 5, 5},
			//{5, 1, 2, 3, 4, 5},
			//{1, 4, 3, 2, 1},
			//{1, 6, 7, 8, 9},
			//{1, 2, 3, 4, 3},
			//{9, 8, 7, 6, 7},
			//{7, 10, 8, 10, 11},
			//{29, 28, 27, 25, 26, 25, 22, 20},
		}

		want := 14
		got := countSafeReports02(data)
		if got != want {
			t.Errorf("want %d, got %d", want, got)
		}
	})
}