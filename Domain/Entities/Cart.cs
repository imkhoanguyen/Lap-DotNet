namespace Domain.Entities
{
    public class Cart : BaseEntity
    {
        public DateTime CreatedDay { get; set; } = DateTime.Now;
        //nav
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
