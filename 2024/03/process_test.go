package main

import "testing"

func TestProcess(t *testing.T) {
	t.Run("part1 should return result", func(t *testing.T) {
		want := 161
		data := "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
		got, err := process01(data)

		if err != nil {
			t.Errorf("process01() err = %v; want nil", err)
		}
		if got != want {
			t.Errorf("process01() = %d; want %d", got, want)
		}
	})
	t.Run("part2 should return result", func(t *testing.T) {
		want := 48
		data := "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
		got, err := process02(data)

		if err != nil {
			t.Errorf("process01() err = %v; want nil", err)
		}
		if got != want {
			t.Errorf("process01() = %d; want %d", got, want)
		}
	})

}