namespace BookLibraryAPIDemo.Application.Exceptions
{
    public class PublisherNotFoundException : NotFoundException
    { 
        public PublisherNotFoundException( Guid PublisherId) : base ($" Publisher with id : {PublisherId} is not found") {
        }
    }
}