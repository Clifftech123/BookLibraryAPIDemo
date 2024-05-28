namespace BookLibraryAPIDemo.Domain.Entities
{
    public class Publisher
    {

        // BusinessLogics 
        public int Id { get; set; }
         public string PublisherName { get; set; }
        public List<Book> Books { get; set; }
    }
}