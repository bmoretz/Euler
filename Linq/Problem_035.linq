<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

Q: How many circular primes are there below one million?
A: 55

*/

int[] getRotations( int n )
{
	char[] str = n.ToString().ToCharArray();
	
	int[] rotations = new int[ str.Length ];
	
	rotations[ 0 ] = n;
	
	int offset = 1;
	
	for( int i = 1; i < str.Length; i++ )
	{		
		char temp = str[ 0 ];
		
		for( int j = 0; j < ( str.Length - 1 ); j++ )
		{
			str[ j ] = str[ j + 1 ];
		}
		
		str[ str.Length - 1 ] = temp;
		
		rotations[ i ] = Int32.Parse( new String( str ) );
	}
	
	return rotations;
}

bool isPrime( int x )
{
	if( x == 1 ) return false;
	
	if( x < 4 ) return true;
	
	if( x % 2 == 0 ) return false;
	
	if( x < 9 )
		return true;
	
	if( x % 3 == 0 ) return false;
	
	int r = ( int ) Math.Sqrt( x );
	int f = 5;
	
	while( f <= r )
	{
		if( x % f == 0 ) return false;
		if( x % ( f + 2 ) == 0 ) return false;
		
		f += 6;
	}
	
	return true;
}

void Main()
{
	List<int> circularPrimes = new List<int>();
	
	for( int i = 1; i < 1000000; i++ )
	{
		if( isPrime( i ) )
		{
			bool isCircular = true;
			
			int[] rotations = getRotations( i );
			
			for( int k = 1; k < rotations.Length; k++ )
			{
				isCircular &= isPrime( rotations[ k ] );
			}
			
			if( isCircular )
				circularPrimes.Add( i );
		}
	}
	
	circularPrimes.Dump();
}