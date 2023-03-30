using System.Collections.Generic;

namespace TNE.Domain.Entities
{
    public abstract class Row : Entity
    {
        public abstract RowType Type { get; }

        public string FileName { get; set; }

        public long BookId { get; set; }
        public Book Book { get; set; }

        public long Page { get; set; }
        public long Index { get; set; }

        public abstract int GetLevel();

        public int Level { get; set; }

        public ICollection<RowImage> Images { get; set; }

        public bool Copiable { get; set; } = true;
    }
}