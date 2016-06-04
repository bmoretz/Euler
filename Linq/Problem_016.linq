<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

Q: What is the sum of the digits of the number 2^1000?

A: 1366

*/

BigInteger n = BigInteger.Pow( 2, 1000 );

List<int> digits = new List<int>();

Array.ForEach( n.ToString().ToCharArray(), c => digits.Add( int.Parse( c.ToString() ) ) );

digits.Sum().Dump();