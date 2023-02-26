using System.Reflection;

namespace Benchmarks;

public static class BenchmarkProvider
{
	/// <summary>
	///		Get all benchmark classes.
	/// </summary>
	/// <returns>All classes implementing the benchmark interface.</returns>
	private static IEnumerable<Type> GetBenchmarkClasses()
	{
		var types = Assembly.GetExecutingAssembly().GetTypes();
		return types.Where(type => type.GetInterfaces().Contains(typeof(IBenchmark)));
	}
	
	/// <summary>
	///		Get all benchmarks.
	/// </summary>
	/// <returns>Dictionary with benchmark titles as keys, class types as values.</returns>
	public static IDictionary<string, Type> GetBenchmarks()
	{
		var benchmarkClasses = GetBenchmarkClasses().ToList();

		var titles = benchmarkClasses
			.Select(t => t.GetProperty("Title")!.GetValue(null))
			.Select(t=>(string)t!)
			.ToList();

		var benchmarks = benchmarkClasses
			.Zip(titles, (type, title) => new { title, type })
			.ToDictionary(p => p.title, p => p.type);

		return benchmarks;
	}
}