<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

/*

If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.

Answer: 21124

*/

Dictionary<int,string> baseNumerTable = new Dictionary<int,string>();

void Main()
{
	BuildNumberTable();
	
	for( int i = 1; i < 1001; i++ )
	{
		convertNumberToString( i );
	}
	
	var values = baseNumerTable.OrderBy( n => n.Key ).Skip( 1 );
	
	var result = values.Sum( n => GetValueLength( n.Value ) );
	
	result.Dump();
}

int GetValueLength( string value )
{
	return value.Replace( " ", String.Empty ).Replace( "-", String.Empty ).Length;
}

string convertNumberToString( int n )
{
	string number = n.ToString(), stringValue = String.Empty;
	
	if( baseNumerTable.ContainsKey( n ) )
	{
		stringValue = String.Concat
		(
			baseNumerTable[ n ]
		);
	}
	else if( n < 100 )
	{
		char[] integers = n.ToString().ToCharArray();
		
		stringValue = String.Concat
		(
			baseNumerTable[ int.Parse( String.Concat( integers[ 0 ], 0 ) ) ],
			"-",
			baseNumerTable[ int.Parse( integers[ 1 ].ToString() ) ]
		);
		
		baseNumerTable.Add( n, stringValue );
	} 
	else if( n < 1000 ) 
	{
		char[] integers = n.ToString().ToCharArray();
		
		int num = int.Parse( String.Concat( integers[ 1 ].ToString(), String.Concat( integers[ 2 ].ToString() ) ) );
		
		stringValue = String.Concat
		(
			String.Concat( baseNumerTable[ int.Parse( String.Concat( integers[ 0 ] ) ) ], " Hundred" ),
			num == 0 ? String.Empty : " and ",
			baseNumerTable[ num ]
		);
		
		baseNumerTable.Add( n, stringValue );
	}
	
	return stringValue;
}

void BuildNumberTable()
{
	baseNumerTable.Add( 0, "" );
	baseNumerTable.Add( 1, "One" );
	baseNumerTable.Add( 2, "Two" );
	baseNumerTable.Add( 3, "Three" );
	baseNumerTable.Add( 4, "Four" );
	baseNumerTable.Add( 5, "Five" );
	baseNumerTable.Add( 6, "Six" );
	baseNumerTable.Add( 7, "Seven" );
	baseNumerTable.Add( 8, "Eight" );
	baseNumerTable.Add( 9, "Nine" );
	baseNumerTable.Add( 10, "Ten" );
	baseNumerTable.Add( 11, "Eleven" );
	baseNumerTable.Add( 12, "Twelve" );
	baseNumerTable.Add( 13, "Thirteen" );
	baseNumerTable.Add( 14, "Fourteen" );
	baseNumerTable.Add( 15, "Fifteen" );
	baseNumerTable.Add( 16, "Sixteen" );
	baseNumerTable.Add( 17, "Seventeen" );
	baseNumerTable.Add( 18, "Eighteen" );
	baseNumerTable.Add( 19, "Nineteen" );
	baseNumerTable.Add( 20, "Twenty" );
	baseNumerTable.Add( 30, "Thirty" );
	baseNumerTable.Add( 40, "Forty" );
	baseNumerTable.Add( 50, "Fifty" );
	baseNumerTable.Add( 60, "Sixty" );
	baseNumerTable.Add( 70, "Seventy" );
	baseNumerTable.Add( 80, "Eighty" );
	baseNumerTable.Add( 90, "Ninety" );
	baseNumerTable.Add( 100, "One Hundred" );
	baseNumerTable.Add( 1000, "One Thousand" );
}