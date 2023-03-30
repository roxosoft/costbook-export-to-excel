using System;
using System.Collections.Generic;
using System.Text;

namespace TNE.Domain.Entities
{
    public class CustomCostRow : DataRow
    {
        public string Name { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public long UnitOfMeasureId { get; set; }
        public string Costs { get; set; }
        public override RowType Type => RowType.CustomCost;
    }
}

