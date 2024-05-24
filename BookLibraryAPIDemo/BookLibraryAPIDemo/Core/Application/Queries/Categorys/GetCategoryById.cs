using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.BookLibraryAPICategory
{

    public class GetCategoryById : IRequest<CategoryDTO>
    {
        public int CategoryId { get; set; }
    }

    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, CategoryDTO>
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IBaseRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.CategoryId);
            if (category == null) { throw new CategoryNotFoundException(request.CategoryId); }
            var categoryModel = _mapper.Map<CategoryDTO>(category);
            return categoryModel;
        }
    }
}