using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.Authors
{
    public class GetAuthorById : IRequest<AuthorDTO>
    {
        public int AuthorId { get; set; }
    }
    public class UpdateAuthorHandler : IRequestHandler<GetAuthorById, AuthorDTO>
    {
        private readonly IBaseRepository<Author> _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorHandler(IBaseRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Handle(GetAuthorById request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.AuthorId);
            if (author == null) { throw new AuthorNotFoundException(request.AuthorId); }

            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;

        }
    }
}