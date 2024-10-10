namespace Domain.Entities
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
