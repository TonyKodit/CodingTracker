using ConsoleTableExt;

internal class TableVisualisation1
{
    internal static void ShowTable<T>(List<T> tableData) where T : class
    {
        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithTitle("Workout")
            .ExportAndWriteLine();
        Console.WriteLine("\n\n");

    }
}