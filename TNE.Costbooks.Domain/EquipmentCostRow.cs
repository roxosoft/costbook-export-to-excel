namespace TNE.Domain.Entities
{
    public class EquipmentCostRow : DataRow
    {
        public long EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public decimal DayPrice { get; set; }
        public decimal WeekPrice { get; set; }
        public decimal MonthPrice { get; set; }

        public override RowType Type => RowType.EquipmentCost;
    }
}