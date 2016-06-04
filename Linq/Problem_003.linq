<Query Kind="Program" />

/*

The prime factors of 13195 are 5, 7, 13 and 29.

Q: What is the largest prime factor of the number 600851475143 ?

A: 71, 839, 1471 and 6857.

*/

Predicate<ulong> isPrime = new Predicate<ulong>
(
	x =>
	{
		if( x == 1 ) return false;
		
		if( x < 4 ) return true;
		
		if( x % 2 == 0 ) return false;
		
		if( x < 9 )
			return true;
		
		if( x % 3 == 0 ) return false;
		
		ulong r = ( ulong ) Math.Sqrt( x );
		ulong f = 5;
		
		while( f <= r )
		{
			if( x % f == 0 ) return false;
			if( x % ( f + 2 ) == 0 ) return false;
			
			f += 6;
		}
		
		return true;
	}
);

void Main()
{
	ulong number = 600851475143;
	
	ulong r = ( ulong ) Math.Sqrt( number );
	
	for( ulong i = 2; i < r; i++ )
	{
		if( isPrime( i ) && number % i == 0 )
			i.Dump();
	}
}