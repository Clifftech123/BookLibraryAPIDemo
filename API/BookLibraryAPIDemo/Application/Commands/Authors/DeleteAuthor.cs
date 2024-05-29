using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Authors
{

    public class DeleteAuthor : IRequest<string>
    {
        public int AuthorId { get; set; }
    }

    public class DeleteBookHandler : IRequestHandler<DeleteAuthor, string>
    {
        private readonly IBaseRepository<Author> _repository;

        public DeleteBookHandler(IBaseRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeleteAuthor request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.AuthorId);
            if (author == null) { throw new AuthorNotFoundException(request.AuthorId); }
            await _repository.DeleteAsync(author);

            return $"Author with id {request.AuthorId} was successfully deleted.";
        }
    }

}