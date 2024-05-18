using BookLibraryAPIDemo.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookLibraryAPIDemo.Application.Commands.Auth
{

    public class RegisterUser : IRequest<IdentityResult>
    {
        public RegisterUserDTO Model { get; set; }
    }

    public class RegisterUserHandler : IRequestHandler<RegisterUser, IdentityResult>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterUserHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.Model.Username,
                Email = request.Model.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Model.Password);

            return result;
        }
    }
}