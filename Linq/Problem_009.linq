<Query Kind="Statements" />

/*

A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a2 + b2 = c2

For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.

Answer: a: 200, b: 375, c: 425, Product: 31875000
*/

int desiredResult = 1000;

for( int c = 3; c < desiredResult; c++ )
{
	for( int b = 2; b < desiredResult; b++ )
	{
		for( int a = 1; a < desiredResult; a++ )
		{
			if( ( a * a ) + ( b * b ) == ( c * c ) && ( a + b + c == desiredResult ) && ( a < b && b < c ) )
			{
				Console.WriteLine( String.Format( "a: {0}, b: {1}, c: {2}, Answer: {3}", a, b, c, a * b * c ) ); 
			}
		}
	}
}