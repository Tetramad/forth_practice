SRC=${wildcard *.fs}

.PHONY: run
run:
	clear
	gforth $(SRC) -e bye
