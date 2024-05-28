using Microsoft.AspNetCore.Identity;

namespace BookLibraryAPIDemo.Domain.Entities
{
    public class RegisterUserResult
    {
        public IdentityResult IdentityResult { get; set; }
        public string Message { get; set; }
    }
}
