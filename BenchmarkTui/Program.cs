using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Benchmarks;
using BenchmarkTui;
using BenchmarkTui.SpectreConsole;
using Spectre.Console;

var benchmarks = BenchmarkProvider.GetBenchmarks();
var selectedBenchmarkTitle = AnsiConsole.Prompt(
	new SelectionPrompt<string>()
		.Title("Select your desired benchmark:".Bold())
		.AddChoices(benchmarks.Keys));

AnsiConsole.MarkupLine($"Benchmark: {selectedBenchmarkTitle}".Bold());
var summary = RunBenchmark(benchmarks, selectedBenchmarkTitle);
WriteResult(summary);

static Summary RunBenchmark(IDictionary<string, Type> dictionary, string s)
{
	dictionary.TryGetValue(s, out var benchmarkType);

	return AnsiConsole
		.Status()
		.Start("Benchmark is running...", _ => BenchmarkRunner.Run(benchmarkType!, new Config()));
}

static void WriteResult(Summary summary)
{
	var result = SummaryToResultMapper.Map(summary);
	SpectreConsole.WriteTable(result.Table.Titles, result.Table.Cells);
	SpectreConsole.WritePanel("Results path", result.ResultsPath);
	SpectreConsole.WritePanel("Log file path", result.LogPath);
	SpectreConsole.WritePanel("Execution time", $"Execution took {result.Seconds:F0} seconds");
}