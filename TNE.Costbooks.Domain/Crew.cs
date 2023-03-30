namespace TNE.Domain.Entities
{
    public class Crew : Entity, INamedEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public decimal? HourlyWadge { get; set; }

        public string Name
        {
            get { return Code; }
            set { Code = value; }
        }
    }
}