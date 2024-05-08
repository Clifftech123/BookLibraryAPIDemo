using BookLibraryAPIDemo.InfrastructureLayer.Data;
using BookLibraryAPIDemo.InfrastructureLayer.Repositories.Contracts;

namespace BookLibraryAPIDemo.InfrastructureLayer.Repositories.UnitOfWork
{
    public class RepositoriesWrapper : IRepositoriesWrapper
    {
        private readonly LibraryDbContext _dbContext;
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private bool _isDisposed;

        public RepositoriesWrapper(LibraryDbContext dbContext) { _dbContext = dbContext; }

        public IBookRepository Books
            => _bookRepository ??= new BookRepository(_dbContext);

        public IUserRepository Users
            => _userRepository ??= new UserRepository(_dbContext);

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _isDisposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}