<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

/*

A palindromic number reads the same both ways. 

The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Q: Find the largest palindrome made from the product of two 3-digit numbers.
A: 906609

*/

List<int> palindromes = new List<int>();

Predicate<int> isPalindrome = new Predicate<int>
(
	x => 
	{
		string val = x.ToString();
		
		int splitLength = val.Length / 2;
		
		if( val.Length == 1 )
			return false;
			
		string p1 = val.Remove( 0, val.Length % 2 == 0 ? splitLength : splitLength + 1 );
		string p2 = new string( val.Remove( splitLength ).ToCharArray().Reverse().ToArray() );
		
		return p1.Equals( p2 );
	}
);

List<int> numbers = new List<int>();

for( int x = 0; x < 1000; x++ )
{
	for( int y = 0; y < 1000; y++ )
	{
		numbers.Add( x * y );
	}
}

numbers.Where( n => isPalindrome( n ) ).OrderByDescending( n => n ).Dump();