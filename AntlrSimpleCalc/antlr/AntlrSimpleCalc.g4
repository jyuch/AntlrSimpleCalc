grammar AntlrSimpleCalc;

expr
    : '(' expr ')'
	| left=expr op=('*' | '/') right=expr
	| left=expr op=('+' | '-') right=expr
	| NUM
    ;

NUM: DEC_DIGIT+ ('.' DEC_DIGIT+)?;

fragment DEC_DIGIT: [0-9];

SPACE: [ ]+    -> skip;
