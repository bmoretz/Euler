<Query Kind="Program">
  <Connection>
    <ID>2f8c41c6-3ee3-4031-b3f5-2a47f4f9e555</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>AdventureWorksDW</Database>
    <ShowServer>true</ShowServer>
  </Connection>
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

Find the maximum total from top to bottom of the triangle below:

              75
             95 64
            17 47 82
           18 35 87 10
          20 04 82 47 65
         19 01 23 75 03 34
        88 02 77 73 07 63 67
       99 65 04 28 06 16 70 92
      41 41 26 56 83 40 80 70 33
     41 48 72 33 47 32 37 16 94 29
    53 71 44 65 25 43 91 52 97 51 14
   70 11 33 28 77 73 17 78 39 68 17 57
  91 71 52 38 17 14 91 43 58 50 27 29 48
 63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.

However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)

A: 1074

*/

string triangle = 
@"            75
			 95 64
			17 47 82
		   18 35 87 10
		  20 04 82 47 65
		 19 01 23 75 03 34
		88 02 77 73 07 63 67
	   99 65 04 28 06 16 70 92
	  41 41 26 56 83 40 80 70 33
	 41 48 72 33 47 32 37 16 94 29
	53 71 44 65 25 43 91 52 97 51 14
   70 11 33 28 77 73 17 78 39 68 17 57
  91 71 52 38 17 14 91 43 58 50 27 29 48
 63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
";

void Main()
{
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