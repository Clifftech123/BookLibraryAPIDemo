using BookLibraryAPIDemo.InfrastructureLayer.Repositories.Contracts;

namespace BookLibraryAPIDemo.InfrastructureLayer.Repositories.UnitOfWork
{
    public interface IRepositoriesWrapper : IDisposable
    {
        IBookRepository Books { get; }

        IUserRepository Users { get; }
    }
}