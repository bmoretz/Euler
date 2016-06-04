<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

/*

The sum of the squares of the first ten natural numbers is,
12 + 22 + ... + 102 = 385

The square of the sum of the first ten natural numbers is,
(1 + 2 + ... + 10)2 = 552 = 3025

Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

*/

List<int> nums = new List<int>();

nums.AddRange( Enumerable.Range( 1, 100 ) );

var squareOfSums = nums.Select( n => n * n ).Sum();
var sumOfSquares = nums.Sum() * nums.Sum();

var difference = sumOfSquares - squareOfSums;

difference.Dump();