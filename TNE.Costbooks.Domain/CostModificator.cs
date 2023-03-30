using System.Collections.Generic;

namespace TNE.Domain.Entities
{
    public class CostModificator : Entity
    {
        public long AreaId { get; set; }
        public Area Area { get; set; }
        public decimal Material { get; set; }
        public decimal Labor { get; set; }
        public decimal Equipment { get; set; }
    }
}
