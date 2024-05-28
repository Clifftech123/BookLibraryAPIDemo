using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.Publishers
{
    public class GetPublisherById : IRequest<PublisherDTO>
    {
        public int PublisherId { get; set; }

        public class GetPublisherByIdHandler : IRequestHandler<GetPublisherById, PublisherDTO>
        {
            private readonly IBaseRepository<Publisher> _repository;
            private readonly IMapper _mapper;

            public GetPublisherByIdHandler(IBaseRepository<Publisher> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PublisherDTO> Handle(GetPublisherById request, CancellationToken cancellationToken)
            {
                var publisher = await _repository.GetByIdAsync(request.PublisherId);
                if (publisher == null) { throw new PublisherNotFoundException(request.PublisherId); }
                var results = _mapper.Map<PublisherDTO>(publisher);
                return results;
            }
        }
    }
}