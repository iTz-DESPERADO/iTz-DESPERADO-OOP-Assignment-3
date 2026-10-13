namespace RefactoringLab.Part02.Reports;

public class CsvReportExporter : Exporter
{
    public override string FileExtension => "csv";
    
    protected override string Format(List<string[]> rows) =>
        string.Join(Environment.NewLine, rows.Select(r => string.Join(",", r)));
 
}
