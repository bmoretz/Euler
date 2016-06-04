<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

/*

Using names.txt (right click and 'Save Link/Target As...'),

a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, 

when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, 
is the 938th name in the list.

So, COLIN would obtain a score of 938 × 53 = 49714.

Q: What is the total of all the name scores in the file?

A: 871198282

*/

const string namesTextPath = @"C:\Users\Brandon\Documents\LINQPad Queries\Project Euler\names.txt";
const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 

List<char> lookup = new List<char>();

lookup.AddRange( alphabet.ToCharArray() );

List<string> names = File.ReadAllText( namesTextPath ).Split( ',' ).Select( n => n.Replace( "\"", "" ) ).ToList<string>();

names.Sort();

Func<string, int> getNameScore = new Func<string,int>
(
	n =>
	{
		int sum = 0;
		
		foreach( char c in n.ToCharArray() )
		{
			sum += lookup.IndexOf( c ) + 1;
		}
		
		return sum;
	}
);

int output = 0;

for( int index = 0; index < names.Count; index++ )
{
	output += getNameScore( names[ index ] ) * ( index + 1 );
}

output.Dump();