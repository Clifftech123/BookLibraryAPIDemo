using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.BookLibraryAPICategory
{

    public class CreateCategory : IRequest<CategoryDTO>
    {
        public CategoryDTO? Model { get; set; }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategory, CategoryDTO>
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IBaseRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.Model);
            await _repository.CreateAsync(category);
            return request.Model!;
        }
    }
}