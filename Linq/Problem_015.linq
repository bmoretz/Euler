<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

Starting in the top left corner of a 2×2 grid, there are 6 routes (without backtracking) to the bottom right corner.

How many routes are there through a 20×20 grid?

n --> #
2 --> 6
3 --> 20
4 --> 70
5 --> 252

Therefore, N chose K, where N = GridSize * 2, k = GridSize

20 --> 137846528820

*/

Func<BigInteger, BigInteger> fac = default( Func<BigInteger, BigInteger > );

fac = f => f == 0 ? 1 : f * fac(f - 1);

int gridSize = 20;

int n = gridSize * 2, k = gridSize;

var result = fac( n ) / ( fac( k ) * fac( n - k ) );

result.Dump();