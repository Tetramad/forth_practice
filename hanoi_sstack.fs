s" sstack.fs" included

: hanoi ( sstack_addr[ c_from c_store c_to ] n -- )
dup 0<= if
	drop dup dup sstack> drop sstack> drop sstack> drop
else
	1- swap >r ( n-1 / stack[ f s t ] )
	r@ sstack> r@ sstack> r@ sstack> ( n-1 t s f / stack[] )
	swap dup r@ sstack! ( n-1 t f s / stack[ s ] )
	swap dup r@ sstack! ( n-1 t s f / stack[ s f ] )
	2swap dup r@ sstack! ( s f n-1 t / stack[ s f t ] )
	swap dup r@ sstack! ( s f t n-1 / stack[ s f t n-1 ] )
	swap dup r@ sstack! ( s f n-1 t / stack[ s f t n-1 t ] )
	2swap dup r@ sstack! r@ sstack! ( n-1 t s / stack[ s f t n-1 t f f ] )
	swap r@ sstack! r@ sstack! r@ sstack! ( / stack[ s f t n-1 t f f t s n-1 ] )
	r> ( stack[ s f t n-1 t f f t s n-1 ] )
	( stack[ s f t n-1 t f f t s n-1 ] ) dup dup sstack> recurse
	( stack[ s f t n-1 t f ] ) dup sstack> emit space dup sstack> emit cr
	( stack[ s f t n-1 ] ) dup sstack> recurse
endif ;
