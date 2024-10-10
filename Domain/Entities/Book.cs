namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public bool Available { get; set; } = false;
        public bool Publisher { get; set; } = false;
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;
        // nav
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public List<BookCatalogue> BookCatalogues { get; set; } = [];

    }
}
