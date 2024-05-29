using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace BookLibraryAPIDemo.Infrastructure.Repositories
{
    public class BookWithRelationsSpecification : ISpecification<Book>
    {
        public Expression<Func<Book, bool>> Criteria { get; }

        public List<Expression<Func<Book, object>>> Includes { get; }

        public BookWithRelationsSpecification()
        {
            Includes = new List<Expression<Func<Book, object>>>
        {
            book => book.Author,
            book => book.Category,
            book => book.Publisher
        };
        }
    }

}
