using Spectre.Console;

namespace BenchmarkTui.SpectreConsole;

internal static class SpectreConsole
{
	public static void WritePanel(string title, string content)
	{
		var resultsPathPanel = new Panel(content)
		{
			Header = new PanelHeader(title.Bold()),
			Expand = true
		};

		AnsiConsole.Write(resultsPathPanel);
	}

	public static void WriteTable(IEnumerable<string> titles, IEnumerable<IEnumerable<string>> cells)
	{
		var table = new Table
		{
			Expand = true
		};

		var titlesList = titles.ToList();

		table.AddColumn(titlesList.First(), c => c.LeftAligned());

		foreach (var column in titlesList.Skip(1))
		{
			table.AddColumn(column.Bold(), c => c.RightAligned());
		}

		foreach (var row in cells)
		{
			table.AddRow(row.ToArray());
		}

		AnsiConsole.Write(table);
	}
}