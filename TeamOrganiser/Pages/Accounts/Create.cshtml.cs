using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamOrganiser.Data;
using TeamOrganiser.Models.Account;

namespace TeamOrganiser
{
    public class CreateModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public CreateModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public AccountType AccountType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyUserAccount = new UserAccount();

            if (await TryUpdateModelAsync<UserAccount>(
                emptyUserAccount,
                "useraccount",
                u => u.Name, u => u.AccountType, u => u.Email, u => u.Password))
            {
                _context.UserAccount.Add(emptyUserAccount);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}
