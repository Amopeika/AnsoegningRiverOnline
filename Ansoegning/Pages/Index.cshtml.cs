using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ansoegning.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _UserService;

        public List<User> users { get; set; }
        public User newUser { get; set; }
        public User editUser { get; set; }

        public IndexModel(IUserService IUserService)
        {
            _UserService = IUserService;
        }

        public async Task OnGetAsync()
        {
            users = await _UserService.GetAllUsersAsync();
            newUser = new User();
            editUser = new User();
        }

        public async Task getUpdateUser(int ID)
        {
            editUser = await _UserService.GetUserByIDAsync(ID);
        }

        public async Task OnPostUpdateUser()
        {
            await _UserService.UpdateUserAsync(editUser);
            await OnGetAsync();
        }
    }
}
