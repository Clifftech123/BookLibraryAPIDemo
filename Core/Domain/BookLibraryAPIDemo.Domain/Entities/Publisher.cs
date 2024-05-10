namespace BookLibraryAPIDemo.Domain.Entities
{
    public class Publisher
    {

        // BusinessLogics 
        public Guid Id { get; set; }
         public string PublisherName { get; set; }
        public List<Book> Books { get; set; }
    }
}