<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.XML.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Linq.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>C:\Projects\Libraries\HtmlAgilityPack\HtmlAgilityPack.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Windows.Presentation.dll</Reference>
  <Reference>C:\Projects\Misc\DynamicLinq\DynamicLinq\bin\Release\DynamicLinq.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Numerics</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Linq.Expressions</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Linq</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>HtmlAgilityPack</Namespace>
</Query>

/*

By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom in triangle.txt (right click and 'Save Link/Target As...'), a 15K text file containing a triangle with one-hundred rows.

NOTE: This is a much more difficult version of Problem 18. It is not possible to try every route to solve this problem, as there are 299 altogether! If you could check one trillion (1012) routes every second it would take over twenty billion years to check them all. There is an efficient algorithm to solve it. ;o)

*/

void Main()
{
	string triangle = String.Join( "\n", File.ReadAllLines(@"C:\Users\Brandon\Documents\LINQPad Queries\Project Euler\triangle.txt") );
	
	List<List<int>> numbers = ParseTriangle( triangle );
	
	for (int i = numbers.Count-2; i >= 0; i--)
	{
		for (int j = 0; j < numbers[i].Count; j++)
		{
			numbers[i][j] += Math.Max(numbers[i + 1][j], numbers[i + 1][j + 1]);
		}
	}

	numbers[0].Dump();
}

List<List<int>> ParseTriangle( string input )
{	
	string[] lines = input.Split( new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries );
	
	List<List<int>> numberArray = new List<List<int>>();
	
	foreach( string line in lines )
	{
		int temp = 0;
		
		List<int> numbers = new List<int>
		(
			from
				number in line.Trim().Split( new char[] { ' ' } )
			where
				Int32.TryParse( number, out temp )
			select temp
		);
		
		numberArray.Add( numbers );
	}
	
	return numberArray;
}