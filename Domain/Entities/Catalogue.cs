namespace Domain.Entities
{
    public class Catalogue : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } = false;
        //nav
        public List<BookCatalogue> BookCatalogues { get; set; } = [];
    }
}
