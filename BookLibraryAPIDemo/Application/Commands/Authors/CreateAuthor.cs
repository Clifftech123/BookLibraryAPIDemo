using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Authors
{



    public class CreateAuthor : IRequest<AuthorDTO>

    {
        public AuthorDTO? Author { get; set; }


        public class CreateAuthorHandler : IRequestHandler<CreateAuthor, AuthorDTO>
        {
            private readonly IBaseRepository<Author> _repository;
            private readonly IMapper _mapper;

            public CreateAuthorHandler(IBaseRepository<Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<AuthorDTO> Handle(CreateAuthor request, CancellationToken cancellationToken)
            {
                var author = _mapper.Map<Author>(request.Author);
                await _repository.CreateAsync(author);
                return request.Author;

            }
        }

    }

}