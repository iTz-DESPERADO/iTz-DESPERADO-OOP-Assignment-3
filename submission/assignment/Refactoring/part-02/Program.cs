using RefactoringLab.Part02.Enrollment;
using RefactoringLab.Part02.Reports;

Console.WriteLine("=== Reports ===");
var outDir = Path.Combine(Path.GetTempPath(), "refactoring-lab-part02");
Directory.CreateDirectory(outDir);

var exporterList = new List<Exporter>()
{
    new CsvReportExporter(),
    new JsonReportExporter(),
    new TextReportExporter()
};

foreach (var export in exporterList)
{
    export.Export(Path.Combine(outDir, $"report.{export.FileExtension}"));
}

Console.WriteLine($"Wrote reports to {outDir}");
Console.WriteLine();

Console.WriteLine("=== Enrollment ===");

var studentId = "S100";
var courseId = "CS201";
var amount = 1500m;

var enrollmentFacade = new EnrollmentFacade();

enrollmentFacade.EnrollCourse(studentId, courseId, amount);



