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

        [BindProperty]
        public User newUser { get; set; }

        public IndexModel(IUserService IUserService)
        {
            _UserService = IUserService;
        }

        public async Task OnGetAsync()
        {
            users = await _UserService.GetAllUsersAsync();
            newUser = new User();
        }

        public async Task OnPostNewUserAsync()
        {
            await _UserService.CreateUserAsync(newUser);
            await OnGetAsync();
        }
    }
}
