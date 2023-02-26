namespace BenchmarkTui.SpectreConsole;

internal static class SpectreConsoleMarkupExtensions
{
	public static string Bold(this string self) => $"[bold]{self}[/]";

	public static string Link(this string self, string linkDest ) => $"[link={linkDest}]{self}[/]";
}