using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.Books
{
    public class GetBookById : IRequest<BookDTO>
    {

        public int BookId { get; set; }



        public class GetBookByIdHandler : IRequestHandler<GetBookById, BookDTO>
        {

            private readonly IBaseRepository<Book> _repository;
            private readonly IMapper _mapper;

            public GetBookByIdHandler(IBaseRepository<Book> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<BookDTO> Handle(GetBookById request, CancellationToken cancellationToken)
            {

                var book = await _repository.GetByIdAsync(request.BookId);
                if (book == null) { throw new BookNotFoundException(request.BookId); }
                var bookDTO = _mapper.Map<BookDTO>(book);
                return bookDTO;
            }
        }
    }
}