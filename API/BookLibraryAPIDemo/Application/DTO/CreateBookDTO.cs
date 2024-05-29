namespace BookLibraryAPIDemo.Application.DTO
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
