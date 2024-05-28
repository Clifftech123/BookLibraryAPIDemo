namespace BookLibraryAPIDemo.Domain.Entities
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

}
