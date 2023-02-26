using BenchmarkDotNet.Attributes;

namespace Benchmarks.StringConcatenation;

/// <summary>
///		String concatenation vs. string.Format() 
/// </summary>
public class StringConcatenationVsFormat : IBenchmark
{
	public static string Title => "String concatenation compared to string format";
	
	// String concatenation and interpolation as well as the explicit call to string.Concat
	// should all have similar performance as the first two are lowered into the latter call.
	// See:
	// https://sharplab.io/#v2:CYLg1APgAgTAjAWAFBQMwAJboMLoN7LpGYZQAs6AggBQCU+hxTAbgIYBO6AzgC7uXoAvOgBEACQCmAGykB7ADSiA3MgCQqtp17sAQkNEB1WeynARKpOs3p2ErgFcpPfdoFhufHRaYBfRkX8STAodOgZLDQ50AHdjU30RIxMzCyso2wcnfQAScWk5RTxY5J9zQL8kHyA= 
	
	[Benchmark]
	public string StringConcatenationWithConstants()
	{
		// Concatenation of constants is directly lowered to resulting string,
		// so no concatenation is necessary at runtime.
		const string strA = "Hello, ";
		const string strB = "World";
		return strA + strB;
	}
	
	[Benchmark]
	public string StringConcatenationWithInterning()
	{
		var strA = "Hello, ";
		var strB = "World";
		// String interning is not useful in this case
		// as the lookup takes time.
		return string.Intern(strA + strB);
	}
	
	[Benchmark]
	public string StringConcatenationViaPlusOperator()
	{
		var strA = "Hello, ";
		var strB = "World";
		return strA + strB;
	}

	[Benchmark]
	public string StringInterpolation()
	{
		var world = "World";
		return $"Hello, {world}";
	}
	
	[Benchmark]
	public string StringConcatMethodCall()
	{
		var strA = "Hello, ";
		var strB = "World";
		return string.Concat( strA, strB );
	}
	
	[Benchmark(Baseline = true)]
	public string StringFormatMethodCall()
	{
		var world = "World";
		// JetBrains ReSharper actually suggests using string interpolation here.
		return string.Format("Hello, {0}", world);
	}
}