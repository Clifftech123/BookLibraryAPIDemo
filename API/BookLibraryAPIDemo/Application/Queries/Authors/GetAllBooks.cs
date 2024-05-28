using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.Authors
{
    public class GetAllAuthors : IRequest<List<AuthorDTO>>
    {
        public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthors, List<AuthorDTO>>
        {
            private readonly IBaseRepository<Author> _repository;
            private readonly IMapper _mapper;
            public GetAllAuthorsHandler(IBaseRepository<Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<AuthorDTO>> Handle(GetAllAuthors request, CancellationToken cancellationToken)
            {
                var getAllAuthors = await _repository.GetAllAsync();
                var results = _mapper.Map<List<AuthorDTO>>(getAllAuthors);
                return results;

            }
        }
    }
}