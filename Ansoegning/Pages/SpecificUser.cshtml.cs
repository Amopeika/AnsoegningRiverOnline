using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace Ansoegning.Pages
{
    public class SpecificUserModel : PageModel
    {
        private readonly IUserService _UserService;


        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public User user { get; set; }

        public SpecificUserModel(IUserService IUserService)
        {
            _UserService = IUserService;
        }
        public async Task OnGetAsync()
        {
            user = await _UserService.GetUserByIDAsync(ID);
        }

        public async Task OnPostUpdateUserAsync()
        {
            await _UserService.UpdateUserAsync(user);
            await OnGetAsync();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync()
        {
            await _UserService.DeleteUserAsync(user);
            return RedirectToPage("/Index");
        }
    }
}
