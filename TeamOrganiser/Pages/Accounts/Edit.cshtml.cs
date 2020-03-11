using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models.Account;

namespace TeamOrganiser
{
    public class EditModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public EditModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAccount = await _context.UserAccount.FindAsync(id);

            if (UserAccount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userAccountToUpdate = await _context.UserAccount.FindAsync(id);

            if (await TryUpdateModelAsync<UserAccount>(
            userAccountToUpdate,
            "useraccount",
            s => s.Name, s => s.AccountType, s => s.Email, s => s.Password))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
