namespace TNE.Domain.Entities
{
    public class MaterialCostRow : DataRow
    {
        public override RowType Type => RowType.MaterialCost;

        public Material Material { get; set; }
        public long MaterialId { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }
        public long? UnitOfMeasureId { get; set; }

        public string MaterialPrices { get; set; }
    }
}