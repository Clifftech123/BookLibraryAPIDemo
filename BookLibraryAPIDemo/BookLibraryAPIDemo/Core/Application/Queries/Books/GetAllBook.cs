﻿using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.Books
{
    public class GetAllBook : IRequest<List<BookDTO>>
    {

        public class GetBooksHandler : IRequestHandler<GetAllBook, List<BookDTO>>
        {
            private readonly IBaseRepository<Book> _repository;
            private readonly IMapper _mapper;

            public GetBooksHandler(IBaseRepository<Book> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<BookDTO>> Handle(GetAllBook request, CancellationToken cancellationToken)
            {

                var gettAllBooks = await _repository.GetAllAsync();
                var results = _mapper.Map<List<BookDTO>>(gettAllBooks);
                return results;

            }
        }
    }
}