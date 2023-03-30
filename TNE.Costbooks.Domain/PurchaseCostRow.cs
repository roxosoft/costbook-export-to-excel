namespace TNE.Domain.Entities
{
    public class PurchaseCostRow : DataRow
    {
        public override RowType Type => RowType.PurchaseCost;

        public Equipment Equipment { get; set; }
        public long EquipmentId { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal DayPrice { get; set; }
        public decimal WeekPrice { get; set; }
    }
}