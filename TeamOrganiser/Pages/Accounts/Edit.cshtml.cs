using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<JsonResult> OnGetAsync(int? id)
        {
            UserAccount = await _context.UserAccount.FindAsync(id);

            if (UserAccount == null)
            {
                // insert error handling
            }

            return new JsonResult(UserAccount);
            
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userAccountToUpdate = await _context.UserAccount.FindAsync(id);

            if (await TryUpdateModelAsync(
            userAccountToUpdate,
            "useraccount",
            s => s.Name, s => s.AccountType, s => s.Email, s => s.Password).ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
