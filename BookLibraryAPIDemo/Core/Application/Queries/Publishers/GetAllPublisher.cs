using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Queries.Publishers
{
    public class GetAllPublisher : IRequest<List<PublisherDTO>>
    {


        public class GetAllPublisherHandler : IRequestHandler<GetAllPublisher, List<PublisherDTO>>
        {
            private readonly IBaseRepository<Publisher> _repository;
            private readonly IMapper _mapper;
            public GetAllPublisherHandler(IBaseRepository<Publisher> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<PublisherDTO>> Handle(GetAllPublisher request, CancellationToken cancellationToken)
            {
                var getAllPublisher = await _repository.GetAllAsync();
                var results = _mapper.Map<List<PublisherDTO>>(getAllPublisher);
                return results;

            }
        }


    }
}