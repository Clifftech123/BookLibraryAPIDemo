namespace BookLibraryAPIDemo.Domain.Entities
{

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Title { get; set; }
        public List<Book> Books { get; set; }
    }

}