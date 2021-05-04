using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly AnsoegningContext _AnsoegningContext;
        public UserService(AnsoegningContext ansoegningContext)
        {
            _AnsoegningContext = ansoegningContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _AnsoegningContext.Users.AddAsync(user);
            await _AnsoegningContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIDAsync(int ID)
        {
            return await _AnsoegningContext.Users.FirstOrDefaultAsync(T => T.ID == ID);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _AnsoegningContext.Users.ToListAsync();
        }

        public async Task UpdateUserAsync(User edit)
        {
            User user = await _AnsoegningContext.Users.FirstOrDefaultAsync(T => T.ID == edit.ID);
            user.name = edit.name;
            user.age = edit.age;
            user.gender = edit.gender;
            _AnsoegningContext.Update(user);
            await _AnsoegningContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            User delete = await _AnsoegningContext.Users.FirstOrDefaultAsync(T => T.ID == user.ID);
            _AnsoegningContext.Remove(delete);
            await _AnsoegningContext.SaveChangesAsync();
        }
    }
}
