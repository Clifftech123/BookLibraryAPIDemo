using BookLibraryAPIDemo.InfrastructureLayer.Models;

namespace BookLibraryAPIDemo.InfrastructureLayer.Repositories.Contracts
{

        public interface IUserRepository : IBaseRepository<User>
        {
            bool IsUniqueLogin(string login);
            User? GetUserByLogin(string login);
        }
  
}
