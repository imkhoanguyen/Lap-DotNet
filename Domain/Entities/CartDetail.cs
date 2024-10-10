namespace Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        //nav
        public int BookId { get; set; }
        public int CartId { get; set; }
        public Book? Book { get; set; }
        public Cart? Cart { get; set; }
    }
}
