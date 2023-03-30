using System.Collections.Generic;

namespace TNE.Domain.Entities
{
    public class SectionRow : Row
    {
        public SectionRow()
        {
            Descriptions = new List<SectionDescription>();
            Keywords = new List<SectionKeyword>();
            Subsections = new List<SectionRow>();
            Data = new List<DataRow>();
        }

        public int Number { get; set; }

        public string Title { get; set; }

        public IList<SectionDescription> Descriptions { get; private set; }
        public IList<SectionKeyword> Keywords { get; private set; }

        public override RowType Type => RowType.Section;

        public long? ParentId { get; set; }
        public SectionRow Parent { get; set; }

        public IList<SectionRow> Subsections { get; private set; }
        public IList<DataRow> Data { get; private set; }

        public override int GetLevel()
        {
            if (Parent != null)
                return Parent.GetLevel() + 1;

            return 0;
        }
    }
}