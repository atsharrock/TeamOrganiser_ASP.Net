using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamOrganiser.Models.Account;

namespace TeamOrganiser
{
    public class EditAccountModel : PageModel
    {

        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public EditAccountModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public string Message { get; set; } = "Initial Request";
        public async Task<JsonResult> OnGetUserAccount()
        {
            UserAccount = await _context.UserAccount.FindAsync(3);
            Console.WriteLine(UserAccount);
            return new JsonResult(UserAccount);
        }


    }
}