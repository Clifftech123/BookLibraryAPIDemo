using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Books
{
    public class CreateBook : IRequest<BookDTO>

    {
        public CreateBookDTO? Book { get; set; }


        public class CreateBookHandler : IRequestHandler<CreateBook, BookDTO>
        {
            private readonly IBaseRepository<Book> _repository;
            private readonly IMapper _mapper;

            public CreateBookHandler(IBaseRepository<Book> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<BookDTO> Handle(CreateBook request, CancellationToken cancellationToken)
            {
                var book = _mapper.Map<Book>(request.Book);
                await _repository.CreateAsync(book);
                return _mapper.Map<BookDTO>(book);

            }
        }

    }


}



