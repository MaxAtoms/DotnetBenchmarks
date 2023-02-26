using BenchmarkDotNet.Reports;
using BenchmarkTui.SpectreConsole;

namespace BenchmarkTui;

internal static class SummaryToResultMapper
{
	private static readonly IList<string> Titles = new List<string>
		{ "Method", "Mean", "Error", "StdDev", "Gen0", "Gen1", "Allocated" };

	public static BenchmarkTuiResult Map(Summary summary) =>
		new()
		{
			Seconds = summary.TotalTime.TotalSeconds,
			ResultsPath = GetShortenedLink(summary.ResultsDirectoryPath),
			LogPath = GetShortenedLink(summary.LogFilePath),
			Table = GetTableFromSummary(summary)
		};

	private static string GetShortenedLink(string link)
	{
		var baseDir = Path.GetFullPath(AppContext.BaseDirectory);
		var fullPath = Path.GetFullPath(link);

		return fullPath.StartsWith(baseDir)
			? fullPath[baseDir.Length..].TrimStart(Path.DirectorySeparatorChar).Link(link)
			: fullPath.Link(link);
	}

	private static BenchmarkTuiResult.ResultTable GetTableFromSummary(Summary summary)
	{
		IEnumerable<string>? GetContent(string header) => summary.Table.Columns
			.FirstOrDefault(c => c.Header == header)?
			.Content;
		var columns = Titles.Select(GetContent).Where(c => c is not null);
		var tableCells = Utils.Transpose(columns!);

		return new BenchmarkTuiResult.ResultTable
		{
			Titles = Titles,
			Cells = tableCells
		};
	}
}