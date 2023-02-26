namespace BenchmarkTui;

internal static class Utils
{
	public static IEnumerable<IEnumerable<T>> Transpose<T>(IEnumerable<IEnumerable<T>> enumerable)
	{
		var list = enumerable.ToList();
		return Enumerable.Range(0, list.First().Count())
			.Select(x => list.Select(y => y.ElementAt(x)));
	}
}