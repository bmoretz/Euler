<Query Kind="Statements" />

/*

2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

Q: What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

A: 232792560

*/

Predicate<ulong> isDivisible = new Predicate<ulong>
(
	x =>
	{
		if( x % 19 != 0 ) return false;
		if( x % 18 != 0 ) return false;
		if( x % 17 != 0 ) return false;
		if( x % 16 != 0 ) return false;
		if( x % 13 != 0 ) return false;
		if( x % 11 != 0 ) return false;
		if( x % 7 != 0 ) return false;
		if( x % 5 != 0 ) return false;
		
		return true;
	}
);

ulong n = 1;

while( !isDivisible( n ) )
{
	n++;
}

n.Dump();