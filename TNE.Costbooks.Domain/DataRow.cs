using System;
using System.Collections.Generic;
using System.Text;

namespace TNE.Domain.Entities
{
    public abstract class DataRow: Row
    {
        public long SectionId { get; set; }
        public SectionRow Section { get; set; }

        public override int GetLevel()
        {
            return Section.GetLevel() + 1;
        }

        public long? HeaderId { get; set; }
        public TextRow Header { get; set; }

        public string Title { get; set; }
    }
}
