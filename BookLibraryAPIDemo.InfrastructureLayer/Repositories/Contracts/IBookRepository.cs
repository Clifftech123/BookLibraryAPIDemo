using BookLibraryAPIDemo.InfrastructureLayer.Models;

namespace BookLibraryAPIDemo.InfrastructureLayer.Repositories.Contracts
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Book? GetByIsbn(string isbn);

        bool IsUniqueIsbn(string isbn);
    }
}
