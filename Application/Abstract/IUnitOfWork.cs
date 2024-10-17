namespace Application.Abstract
{
    public interface IUnitOfWork
    {
        IBookRepository Book {  get; }
        IGenreRepository Genre { get; }
        Task<bool> Complete();
    }
}
