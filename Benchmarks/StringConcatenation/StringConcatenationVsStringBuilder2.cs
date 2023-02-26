using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.StringConcatenation;

public class StringConcatenationVsStringBuilder2 : IBenchmark
{
	public static string Title => "String concatenation compared to string builder used in a loop with strings of different lengths";
	
	[Params(1, 10, 100)] 
	public int Iterations { get; set; }

	[Params( "a", "abc", "some longer test string" )]
	public string? TestString { get; set; }

	[Benchmark]
	public string StringBuilderInLoop()
	{
		var stringBuilder = new StringBuilder();

		for (var i = 0; i < Iterations; i++)
		{
			stringBuilder.Append(TestString);
		}

		return stringBuilder.ToString();
	}
	
	[Benchmark]
	public string StringConcatInLoop()
	{
		var testString = "";
		

		for (var i = 0; i < Iterations; i++)
		{
			testString += TestString;
		}

		return testString;
	}
}