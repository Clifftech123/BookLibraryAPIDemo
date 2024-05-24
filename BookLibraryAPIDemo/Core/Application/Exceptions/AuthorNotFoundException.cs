namespace BookLibraryAPIDemo.Application.Exceptions
{
    public class AuthorNotFoundException : NotFoundException
    {

        public AuthorNotFoundException(int authorId) : base($"Author with  id :{authorId} is not found  ")
        {

        }
    }
}