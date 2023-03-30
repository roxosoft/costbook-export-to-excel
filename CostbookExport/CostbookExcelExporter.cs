using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using TNE.Domain;
using TNE.Domain.Entities;

namespace CostbookExport;

internal class CostbookExcelExporter : ICostbookExcelExporter
{
    private const int CategoryColumnIndex = 1;
    private const int DescriptionColumnIndex = 2;
    private const int MaterialColumnIndex = 3;
    private const int LaborColumnIndex = 4;
    private const int TotalColumnIndex = 5;
    private const int ManhoursColumnIndex = 6;
    private const int EquipmentColumnIndex = 7;
    private const int UnitColumnIndex = 8;
    private const int CrewDescriptionColumnIndex = 9;
    private const int CrewCodeColumnIndex = 10;

    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public CostbookExcelExporter(IUnitOfWorkFactory unitOfWorkFactory)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task ExportCostbook(long costbookId, string fileName)
    {
        using var uow = _unitOfWorkFactory.Create();

        var costbookRows = await uow
            .Get<DataRow>()
            .Include("Aggregate")
            .Include("UnitOfMeasure")
            .Include("Crew")
            .Include("Material")
            .Include("Equipment")
            .Include("Book")
            .Where(x => x.BookId == costbookId)
            .OrderBy(x => x.Index)
            .ToListAsync();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        File.Delete(fileName);
        using var xlPackage = new ExcelPackage(new FileInfo(fileName));
        var sheet = xlPackage.Workbook.Worksheets.Add("Costbook Export");

        var rowNumber = 2;
        foreach (var row in costbookRows)
        {
            if (row is TextRow)
            {
                continue;
            }

            if (row is AggregateCostRowMLET)
            {
                AddAggregateMletRow(sheet, rowNumber, (row as AggregateCostRowMLET)!);
                rowNumber++;
                continue;
            }

            if (row is AggregateCostRow)
            {
                AddAggregateRow(sheet, rowNumber, (row as AggregateCostRow)!);
                rowNumber++;
                continue;
            }

            if (row is MaterialCostRow)
            {
                rowNumber += AddMaterialRow(sheet, rowNumber, (row as MaterialCostRow)!);
                continue;
            }

            if (row is EquipmentCostRow)
            {
                AddEquipmentRow(sheet, rowNumber, (row as EquipmentCostRow)!);
                rowNumber += 3;
                continue;
            }

            if (row is CustomCostRow)
            {
                rowNumber += AddCustomRow(sheet, rowNumber, (row as CustomCostRow)!);
                continue;
            }

            if (row is PurchaseCostRow)
            {
                AddPurchaseRow(sheet, rowNumber, (row as PurchaseCostRow)!);
                rowNumber += 3;
                continue;
            }

            throw new NotImplementedException("Export of this row type is not supported");
        }

        AddHeaderRow(sheet);
        xlPackage.Save();
    }

    private void AddPurchaseRow(ExcelWorksheet sheet, int rowNumber, PurchaseCostRow purchase)
    {
        var rentalPeriodNames = JsonConvert.DeserializeObject<string[]>(purchase.Header.Options);
        var rentalPrices = new decimal[] { purchase.PurchasePrice, purchase.DayPrice, purchase.WeekPrice };

        for (var i = 0; i < rentalPrices.Length; i++)
        {
            sheet.Cells[rowNumber + i, CategoryColumnIndex].Value = purchase.Title;
            sheet.Cells[rowNumber + i, DescriptionColumnIndex].Value = purchase.Equipment.Name;
            sheet.Cells[rowNumber + i, MaterialColumnIndex].Value = rentalPrices[i];
            sheet.Cells[rowNumber + i, UnitColumnIndex].Value = rentalPeriodNames[rentalPeriodNames.Length - rentalPrices.Length + i];
        }
    }

    private int AddCustomRow(ExcelWorksheet sheet, int rowNumber, CustomCostRow customCosts)
    {
        var individualNames = JsonConvert.DeserializeObject<string[]>(customCosts.Header.Options);
        var individualPrices = JsonConvert.DeserializeObject<decimal[]>(customCosts.Costs);

        for (var i = 0; i < individualPrices.Length; i++)
        {
            sheet.Cells[rowNumber + i, CategoryColumnIndex].Value = customCosts.Title;
            sheet.Cells[rowNumber + i, DescriptionColumnIndex].Value = $"{customCosts.Name}, {individualNames[individualNames.Length - individualPrices.Length + i]}";
            sheet.Cells[rowNumber + i, MaterialColumnIndex].Value = individualPrices[i];

            if (customCosts.UnitOfMeasure != null)
                sheet.Cells[rowNumber + i, UnitColumnIndex].Value = customCosts.UnitOfMeasure.Name;
        }

        return individualPrices.Length;
    }

    private void AddEquipmentRow(ExcelWorksheet sheet, int rowNumber, EquipmentCostRow equipment)
    {
        var rentalPeriodNames = JsonConvert.DeserializeObject<string[]>(equipment.Header.Options);
        var rentalPrices = new decimal[] { equipment.DayPrice, equipment.WeekPrice, equipment.MonthPrice };

        for (var i = 0; i < rentalPrices.Length; i++)
        {
            sheet.Cells[rowNumber + i, CategoryColumnIndex].Value = equipment.Title;
            sheet.Cells[rowNumber + i, DescriptionColumnIndex].Value = equipment.Equipment.Name;
            sheet.Cells[rowNumber + i, MaterialColumnIndex].Value = rentalPrices[i];
            sheet.Cells[rowNumber + i, UnitColumnIndex].Value = rentalPeriodNames[rentalPeriodNames.Length - rentalPrices.Length + i];
        }
    }

    private int AddMaterialRow(ExcelWorksheet sheet, int rowNumber, MaterialCostRow material)
    {
        var materialName = material.Material.Name;

        var individualNames = JsonConvert.DeserializeObject<string[]>(material.Header.Options);
        var individualPrices = JsonConvert.DeserializeObject<decimal[]>(material.MaterialPrices);

        for (var i = 0; i < individualPrices.Length; i++)
        {
            sheet.Cells[rowNumber + i, CategoryColumnIndex].Value = material.Title;
            sheet.Cells[rowNumber + i, DescriptionColumnIndex].Value = $"{materialName} ({individualNames[individualNames.Length - individualPrices.Length + i]} {individualNames[0]})";
            sheet.Cells[rowNumber + i, MaterialColumnIndex].Value = individualPrices[i];

            if (material.UnitOfMeasure != null)
                sheet.Cells[rowNumber + i, UnitColumnIndex].Value = material.UnitOfMeasure.Name;
        }

        return individualPrices.Length;
    }

    private void AddAggregateMletRow(ExcelWorksheet sheet, int rowNumber, AggregateCostRowMLET aggregate)
    {
        AddAggregateRow(sheet, rowNumber, aggregate);
        sheet.Cells[rowNumber, EquipmentColumnIndex].Value = aggregate.EquipmentPrice == 0 ? string.Empty : aggregate.EquipmentPrice;
    }

    private void AddAggregateRow(ExcelWorksheet sheet, int rowNumber, AggregateCostRow aggregate)
    {
        var isRepairBook = aggregate.Book.Name.Contains("repair", StringComparison.InvariantCultureIgnoreCase);
        sheet.Cells[rowNumber, CategoryColumnIndex].Value = aggregate.Title;
        sheet.Cells[rowNumber, DescriptionColumnIndex].Value = isRepairBook ? $"{aggregate.Name} ({aggregate.Aggregate.Name})" : aggregate.Aggregate.Name;
        sheet.Cells[rowNumber, MaterialColumnIndex].Value = aggregate.MaterialPrice == 0 ? string.Empty : aggregate.MaterialPrice;
        sheet.Cells[rowNumber, LaborColumnIndex].Value = aggregate.LaborPrice == 0 ? string.Empty : aggregate.LaborPrice;
        sheet.Cells[rowNumber, TotalColumnIndex].Value = aggregate.TotalPrice == 0 ? string.Empty : aggregate.TotalPrice;
        sheet.Cells[rowNumber, ManhoursColumnIndex].Value = aggregate.Hours == 0 ? string.Empty : aggregate.Hours;

        if (aggregate.UnitOfMeasure != null)
            sheet.Cells[rowNumber, UnitColumnIndex].Value = aggregate.UnitOfMeasure.Name;

        if (aggregate.Crew != null)
        {
            sheet.Cells[rowNumber, CrewCodeColumnIndex].Value = aggregate.Crew.Code;
            sheet.Cells[rowNumber, CrewDescriptionColumnIndex].Value = $"{aggregate.Crew.Code}: [{aggregate.Crew.HourlyWadge}] - ({aggregate.Crew.Description})";
        }
    }

    private void AddHeaderRow(ExcelWorksheet sheet)
    {
        sheet.Column(CategoryColumnIndex).Width = 45;
        sheet.Column(DescriptionColumnIndex).Width = 55;
        sheet.Column(CrewDescriptionColumnIndex).Width = 50;
        sheet.Row(1).Height = 50;
        sheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
        sheet.Row(1).Style.WrapText = true;
        sheet.Row(1).Style.Font.Bold = true;
        sheet.View.FreezePanes(2, 1);

        sheet.Cells[1, CategoryColumnIndex].Value = "Category";
        sheet.Cells[1, DescriptionColumnIndex].Value = "Description";
        sheet.Cells[1, MaterialColumnIndex].Value = "Material cost per unit";
        sheet.Cells[1, LaborColumnIndex].Value = "Labor cost per unit";
        sheet.Cells[1, TotalColumnIndex].Value = "Lump sum cost";
        sheet.Cells[1, ManhoursColumnIndex].Value = "Manhours per unit";
        sheet.Cells[1, EquipmentColumnIndex].Value = "Equipment cost per unit";
        sheet.Cells[1, UnitColumnIndex].Value = "Unit of measure";
        sheet.Cells[1, CrewDescriptionColumnIndex].Value = "Crew code and detail";
        sheet.Cells[1, CrewCodeColumnIndex].Value = "Crew Code";
    }
}