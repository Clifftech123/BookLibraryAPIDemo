using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Publishers
{
    public class UpdatePublisher : IRequest<PublisherDTO>
    {
        public required PublisherDTO publisher { get; set; }

        public class UpdatePublisherHandler : IRequestHandler<UpdatePublisher, PublisherDTO>
        {
            private readonly IBaseRepository<Publisher> _repository;
            private readonly IMapper _mapper;

            public UpdatePublisherHandler(IBaseRepository<Publisher> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PublisherDTO> Handle(UpdatePublisher request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<Publisher>(request.publisher);
                await _repository.UpdateAsync(model);
                return request.publisher!;
            }
        }
    }
}