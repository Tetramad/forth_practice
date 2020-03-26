: sstack ( u_size -- sstack_addr )
dup 0<= if
  s" positive size only" exception throw
endif
0 ( u_size u_count )
dup cells allocate throw ( u_size u_count storage_addr )
3 cells allocate throw ( u_size u_count storage_addr sstack_addr )
tuck ( u_size u_count sstack_addr storage_addr sstack_addr )
! ( u_size u_count sstack_addr )
tuck ( u_size sstack_addr u_count sstack_addr )
cell+ !
tuck ( sstack_addr u_size sstack_addr )
cell+ cell+ ! ( sstack_addr ) ;

: .sstack ( sstack_addr -- storage_addr u_count u_size )
dup @ swap dup cell+ @ swap cell+ cell+ @ ;

: sstack! ( n sstack_addr -- )
dup cell+ ( n sstack_addr u_count_addr )
dup cell+ ( n sstack_addr u_count_addr u_size_addr )
@ swap @ ( ... u_size u_count )
<= if ( ... )
  s" not enough stack size" exception throw
endif
tuck ( sstack_addr n sstack_addr )
dup @ swap ( sstack_addr n storage_addr sstack_addr )
cell+ @ ( sstack_addr n storage_addr u_count )
cells + ! ( sstack_addr )
cell+ ( u_count_addr )
dup @ 1+ swap ! ;

: sstack@ ( sstack_addr -- n )
dup cell+ @ ( sstack_addr u_count )
dup 0<= if
  s" access top of empty stack" exception throw
endif
1- cells swap @ + @ ;

: sstack> ( sstack_addr -- n )
dup cell+ @ ( sstack_addr u_count )
0<= if ( sstack_addr )
  s" try pop to empty stack" exception throw
endif
dup @ swap ( storage_addr sstack_addr )
cell+ dup @ 1- over ! @ ( storage_addr u_count )
cells + @ ;
