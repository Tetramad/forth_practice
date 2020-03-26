: hanoi ( c_from c_store c_to +n -- )
dup 0<= if
	2drop 2drop
else
	>r >r swap r> r> ( s f t n )
	2over 2over ( s f t n s f t n )
	>r rot >r dup >r ( s f t n f t / n s t )
	swap dup r> r> r> ( s f t n t f f t s n )
	1- recurse emit space emit cr 1- recurse
endif ;
