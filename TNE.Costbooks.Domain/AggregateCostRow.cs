namespace TNE.Domain.Entities
{
    public class AggregateCostRow : DataRow
    {
        public override RowType Type => RowType.AggregateCost;

        public Aggregate Aggregate { get; set; }
        public long AggregateId { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }
        public long UnitOfMeasureId { get; set; }

        public Crew Crew { get; set; }
        public long? CrewId { get; set; }
        public double Hours { get; set; }

        public decimal MaterialPrice { get; set; }

        public decimal LaborPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SellPrice { get; set; }

        public string Name { get; set; }//for special case described in TNE-321
    }
}