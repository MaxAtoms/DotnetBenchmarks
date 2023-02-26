using System.Diagnostics.CodeAnalysis;

namespace Benchmarks;

public interface IBenchmark
{
	[SuppressMessage("ReSharper", "UnusedMember.Global")] 
	public static string Title => null!;
}