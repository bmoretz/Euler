<Query Kind="Statements">
  <Connection>
    <ID>2f8c41c6-3ee3-4031-b3f5-2a47f4f9e555</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>AdventureWorksDW</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Q: Find the sum of the digits in the number 100!

A: 648

*/

Func<BigInteger,BigInteger> fac = default( Func<BigInteger,BigInteger>);

fac = new Func<BigInteger,BigInteger>
(
	n =>
	{
		return n == 1 ? 1 : n * fac( n - 1 );
	}
);

List<int> digits = new List<int>();

Array.ForEach( fac( 100 ).ToString().ToCharArray(), c => digits.Add( int.Parse( c.ToString() ) ) );

digits.Sum().Dump();