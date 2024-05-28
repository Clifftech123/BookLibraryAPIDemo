using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Categorys
{

    public class DeleteCategory : IRequest<Unit>
    {
        public int CategoryId { get; set; }
    }

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, Unit>
    {
        private readonly IBaseRepository<Category> _repository;

        public DeleteCategoryHandler(IBaseRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.CategoryId);
            if (category == null) { throw new CategoryNotFoundException(request.CategoryId); }
            await _repository.DeleteAsync(category);

            return Unit.Value;
        }
    }
}