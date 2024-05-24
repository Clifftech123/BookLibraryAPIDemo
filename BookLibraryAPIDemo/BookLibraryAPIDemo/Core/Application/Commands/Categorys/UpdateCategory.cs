using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Categorys
{

    public class UpdateCategory : IRequest<CategoryDTO>
    {
        public CategoryDTO Model { get; set; }
    }
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, CategoryDTO>
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IBaseRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.Model);
            await _repository.UpdateAsync(category);
            return request.Model!;
        }
    }
}