<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

/*

The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.

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

List<ulong> numbers = new List<ulong>();

numbers.AddRange( Enumerable.Range( 1, 2000000 ).ToList().ConvertAll<ulong>( n => ( ulong ) n ) );

var primes = numbers.Where( n=> isPrime( n ) );

ulong sum = 0;

primes.ToList().ForEach( n => sum += n );

sum.Dump();