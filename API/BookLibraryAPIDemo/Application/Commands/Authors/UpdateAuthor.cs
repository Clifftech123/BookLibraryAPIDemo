using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Authors
{

    public class UpdateAuthor : IRequest<AuthorDTO>
    {
        public UpdateAuthorDTO Author { get; set; }
        public int Id { get; set; }
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
            var existingAuthor = await _repository.GetByIdAsync(request.Id);

            if (existingAuthor == null)
            {
                throw new KeyNotFoundException($"Author with id {request.Id} not found");
            }

            _mapper.Map(request.Author, existingAuthor);

            await _repository.UpdateAsync(existingAuthor);

            return _mapper.Map<AuthorDTO>(existingAuthor);
        }


    }

}