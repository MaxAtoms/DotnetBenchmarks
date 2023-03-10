using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;

namespace BenchmarkTui;

public class Config : ManualConfig
{
	public Config()
	{
		AddExporter(MarkdownExporter.Default);
		AddLogger(NullLogger.Instance);
		AddColumnProvider(DefaultColumnProviders.Instance);
		AddDiagnoser(MemoryDiagnoser.Default);
	}
}