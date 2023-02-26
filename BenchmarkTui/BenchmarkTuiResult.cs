namespace BenchmarkTui;

internal sealed record BenchmarkTuiResult
{
	public required double Seconds { get; init; }

	public required string ResultsPath { get; init; }

	public required string LogPath { get; init; }

	public required ResultTable Table { get; init; }

	internal sealed record ResultTable
	{
		public required IEnumerable<string> Titles { get; init; }
		public required IEnumerable<IEnumerable<string>> Cells { get; init; }
	}
}