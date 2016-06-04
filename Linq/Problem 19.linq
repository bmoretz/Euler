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

You are given the following information, but you may prefer to do some research for yourself.

	1 Jan 1900 was a Monday.
	Thirty days has September,
	April, June and November.
	All the rest have thirty-one,
	Saving February alone,
	Which has twenty-eight, rain or shine.
	And on leap years, twenty-nine.
	A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

*/

int sundays = 0;
 
for (int year = 1901; year <= 2000; year++) {
	for (int month = 1; month <= 12; month++) {
		if ((new DateTime(year, month, 1)).DayOfWeek == DayOfWeek.Sunday) {
			sundays++;
		}
	}
}

sundays.Dump();