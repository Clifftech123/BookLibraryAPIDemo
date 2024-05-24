using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.BookLibraryAPICategory
{

    public class GetAllCategories : IRequest<List<CategoryDTO>> { }

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, List<CategoryDTO>>
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetAllCategoriesHandler(IBaseRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var geAllCategories = await _repository.GetAllAsync();
            var results = _mapper.Map<List<CategoryDTO>>(geAllCategories);
            return results;

        }
    }
}