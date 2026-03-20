package collatzconjecture

import (
	"errors"
	"fmt"
)
func CollatzConjecture(n int) (int, error) {
	if n <= 0 {
		return 0, errors.New("input harus lebih besar dari 0")
	}

	steps := 0

	for n > 1 {
		fmt.Printf("%d ➜ ", n) 
		if n%2 == 0 {
			n = n / 2
		} else {
			n = n*3 + 1
		}
		steps++
	}

	fmt.Printf("%d\n", n)

	return steps, nil
}