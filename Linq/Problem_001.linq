<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

/*

If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 

The sum of these multiples is 23.

Q: Find the sum of all the multiples of 3 or 5 below 1000.

A: 233168

*/

List<int> naturals = new List<int>();

for( int index = 1; index < 1000; index++ )
	naturals.Add( index );

int sum = 
	naturals.Where( n => n % 3 == 0 || n % 5 == 0 ).Sum();
	
sum.Dump();