using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Publishers
{
    public class CreatePublisher : IRequest<PublisherDTO>
    {
        public PublisherDTO? publisher { get; set; }


        public class CreatePublisherHandler : IRequestHandler<CreatePublisher, PublisherDTO>
        {
            private readonly IBaseRepository<Publisher> _repository;
            private readonly IMapper _mapper;

            public CreatePublisherHandler(IBaseRepository<Publisher> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PublisherDTO> Handle(CreatePublisher request, CancellationToken cancellationToken)
            {
                var publisher = _mapper.Map<Publisher>(request.publisher);
                await _repository.CreateAsync(publisher);
                return request.publisher!;
            }
        }
    }
}