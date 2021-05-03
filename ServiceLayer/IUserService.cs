using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIDAsync(int ID);
        Task UpdateUserAsync(User edit);
    }
}