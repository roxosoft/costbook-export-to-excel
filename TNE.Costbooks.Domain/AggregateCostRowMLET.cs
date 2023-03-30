namespace TNE.Domain.Entities
{
    public class AggregateCostRowMLET : AggregateCostRow
    {
        public override RowType Type => RowType.AggregateCostMLET;

        public decimal EquipmentPrice { get; set; }
    }
}