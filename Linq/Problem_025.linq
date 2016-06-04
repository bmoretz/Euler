<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

The Fibonacci sequence is defined by the recurrence relation:

	Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

Hence the first 12 terms will be:

	F1 = 1
	F2 = 1
	F3 = 2
	F4 = 3
	F5 = 5
	F6 = 8
	F7 = 13
	F8 = 21
	F9 = 34
	F10 = 55
	F11 = 89
	F12 = 144

The 12th term, F12, is the first term to contain three digits.

Q: What is the first term in the Fibonacci sequence to contain 1000 digits?
A: 4782

*/

Dictionary<BigInteger,BigInteger> numbers = new Dictionary<BigInteger,BigInteger>();

BigInteger getSequenceLength( BigInteger n )
{
	numbers[ n ] = numbers[ n - 1 ] + numbers[ n - 2 ];
	
	return numbers[ n ];
}

void Main()
{
	numbers.Add( 1, 1 );
	numbers.Add( 2, 1 );
	
	for( BigInteger i = 3; i < 100000; i++)
	{
		int length = getSequenceLength( i ).ToString().Length;
		
		if( length == 1000 )
		{
			i.Dump(); break;
		}
	}
}