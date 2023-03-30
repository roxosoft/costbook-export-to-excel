namespace CostbookExport;

public interface ICostbookExcelExporter
{
    Task ExportCostbook(long costbookId, string fileName);
}