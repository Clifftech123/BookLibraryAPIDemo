namespace BookLibraryAPIDemo.Application.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId) : base($"Category with id: {categoryId} not found.")
        {
        }

    }
}