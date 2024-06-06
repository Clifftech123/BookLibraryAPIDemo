namespace BookLibraryAPIDemo.Client.Models
{
    public class BookModels
    {

        public class Book
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int AuthorId { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string Category { get; set; }
            public int PublisherId { get; set; }
            public string Publisher { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
        }

    }
}
