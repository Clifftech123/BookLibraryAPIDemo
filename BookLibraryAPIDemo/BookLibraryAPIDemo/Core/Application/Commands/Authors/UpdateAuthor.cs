using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Authors
{

    public class UpdateAuthor : IRequest<AuthorDTO>
    {
        public AuthorDTO Model { get; set; }
    }
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthor, AuthorDTO>
    {
        private readonly IBaseRepository<Author> _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorHandler(IBaseRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Handle(UpdateAuthor request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request.Model);
            await _repository.UpdateAsync(author);
            return request.Model!;
        }
    }
}