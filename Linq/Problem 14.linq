<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:
13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. 
Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.

The following iterative sequence is defined for the set of positive integers:

*/

Dictionary<BigInteger, BigInteger> lookup = new Dictionary<BigInteger,BigInteger>( 1000000 );
Dictionary<BigInteger, BigInteger> sequences = new Dictionary<BigInteger,BigInteger>( 1000000 );

BigInteger getSequence( BigInteger n )
{
	BigInteger startingNumber = n;
	
	BigInteger temp;
	
	BigInteger counter = 0;
	
	for( ;; )
	{
		if( sequences.ContainsKey( n ) )
		{
			counter += sequences[ n ]; break;
		} 
		else
		{
			if( lookup.ContainsKey( n ) )
			{
				n = lookup[ n ];
			} 
			else 
			{
				temp = n % 2 == 0 ? 
					n / 2 : 3 * n + 1;
					
				lookup[ n ] = temp;
				
				n = temp;
			}
			
			counter++;
		}
	}
	
	sequences[ startingNumber ] = counter;
	
	return counter;
}

void Main()
{	
	// 13 = 10, 297 = 74, 40011 = 182
	lookup.Add( 1, 1 );
	sequences.Add( 1, 1 );
	
	// getSequence( 13 ).Dump();
	
	List<ulong> numbers = 
		new List<ulong>();
		
	ulong numbercount = 1000000;
	
	for( ulong a = 1; a < numbercount; a++)
		numbers.Add( a );
		
	BigInteger max = 0, number = 0;
	
	for( ulong i = ( ulong )numbers.Count; i > 1; i-- )
	{
		BigInteger current = getSequence( i );
		
		if( current > max )
		{
			max = current;
			number = i;
			Console.WriteLine( String.Format( "Number: {0}, Terms: {1}, Time: {2}", i, max, DateTime.Now ) );
		}
	}
	
	Console.WriteLine( String.Format( "Number: {0}, Terms: {1}", number, max ) );
}