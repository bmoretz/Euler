<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

/*

By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

Q: What is the 10001st prime number?

A: 104743

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

ulong n = 0, current = 0, nth = 10001;

while( true )
{
	if( isPrime( n ) )
	{
		if( current == nth )
			break;
			
		current++;
	}
	
	n++;
};

n.Dump();