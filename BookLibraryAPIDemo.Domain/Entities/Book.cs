namespace BookLibraryAPIDemo.Domain.Entities
{
    
      
        public class Book
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public Guid AuthorId { get; set; }
            public Author Author { get; set; }
            public double Price { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
            public Guid PublisherId { get; set; }
            public Publisher Publisher { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
        }

    


}
