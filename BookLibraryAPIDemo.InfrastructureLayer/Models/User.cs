namespace BookLibraryAPIDemo.InfrastructureLayer.Models
{
    public class User : BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
