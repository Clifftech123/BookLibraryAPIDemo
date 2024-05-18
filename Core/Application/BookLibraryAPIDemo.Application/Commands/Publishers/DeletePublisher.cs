using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Domain.Entities;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using MediatR;

namespace BookLibraryAPIDemo.Application.Commands.Publishers
{
    public class DeletePublisher : IRequest<Unit>
    {
        public int publisherId { get; set; }


        public class DeletePublisherHandler : IRequestHandler<DeletePublisher, Unit>
        {
            private readonly IBaseRepository<Publisher> _repository;

            public DeletePublisherHandler(IBaseRepository<Publisher> repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(DeletePublisher request, CancellationToken cancellationToken)
            {
                var publisher = await _repository.GetByIdAsync(request.publisherId);
                if (publisher == null) { throw new PublisherNotFoundException(request.publisherId); }
                await _repository.DeleteAsync(publisher);

                return Unit.Value;
            }
        }
    }
}