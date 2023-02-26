using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.StringConcatenation;

public class StringConcatenationVsStringBuilder : IBenchmark
{
	public static string Title => "String concatenation compared to string builder when building a string once";
	
	[Benchmark]
	public string StringBuilder()
	{
		var strBuilder = new StringBuilder();
		strBuilder.Append("The ");
		strBuilder.Append("quick ");
		strBuilder.Append("brown ");
		strBuilder.Append("fox ");
		strBuilder.Append("jumped ");
		strBuilder.Append("over ");
		strBuilder.Append("the ");
		strBuilder.Append("lazy ");
		strBuilder.Append("dog.");
		return strBuilder.ToString();
	}

	[Benchmark]
	public string StringConcatenation()
	{
		var str1 = "The ";
		var str2 = "quick ";
		var str3 = "brown ";
		var str4 = "fox ";
		var str5 = "jumped ";
		var str6 = "over ";
		var str7 = "the ";
		var str8 = "lazy ";
		var str9 = "dog.";
		return str1 + str2 + str3 + str4 + str5 + str6 + str7 + str8 + str9;
	}
}