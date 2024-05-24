using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Books
{
    public class UpdateBook : IRequest<BookDTO>
    {
        public required BookDTO Book { get; set; }



        public class UpdateBookHandler : IRequestHandler<UpdateBook, BookDTO>
        {
            private readonly IBaseRepository<Book> _repository;
            private readonly IMapper _mapper;

            public UpdateBookHandler(IBaseRepository<Book> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<BookDTO> Handle(UpdateBook request, CancellationToken cancellationToken)
            {
                var book = _mapper.Map<Book>(request.Book);
                await _repository.UpdateAsync(book);
                return request.Book;
            }
        }

    }





}