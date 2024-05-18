namespace BookLibraryAPIDemo.Application.DTO
{
    public class BookDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Guid PublisherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate{ get; set; }


        }
}