using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models.Account;

namespace TeamOrganiser
{
    public class DeleteAccountsModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public DeleteAccountsModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAccount = await _context.UserAccount
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (UserAccount == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UserAccount = await _context.UserAccount
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (UserAccount == null)
            {
                return NotFound();
            }

            try
            {
                _context.UserAccount.Remove(UserAccount);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
