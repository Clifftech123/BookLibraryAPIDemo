using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Publishers
{
    public class UpdatePublisher : IRequest<PublisherDTO>
    {
        public UpdatePublisherDTO Publisher { get; set; }
        public int Id { get; set; }
    }


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
            var existingPublisher = await _repository.GetByIdAsync(request.Id);

            if (existingPublisher == null)
            {
                throw new KeyNotFoundException($"Publisher with id {request.Id} not found");
            }

            _mapper.Map(request.Publisher, existingPublisher);
            await _repository.UpdateAsync(existingPublisher);
            return _mapper.Map<PublisherDTO>(existingPublisher);
        }

    }
}




