namespace BookLibraryAPIDemo.InfrastructureLayer.Models
{
    internal class Book : BaseModel
    {
        public string Isbn { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime ReturnDate { get; set; }

    }
}
