using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Models.Account;

namespace TeamOrganiser
{
    public class EditAccountsModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public EditAccountsModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> OnGetAsync(int? id)
        {
            var UserAccount = await _context.UserAccounts.FindAsync(id);

            if (UserAccount == null)
            {
                // insert error handling
            }

            return new JsonResult(UserAccount);
            
        }

        public async Task<IActionResult> OnPostAsync(UserAccount userAccount)
        {
            if (!ModelState.IsValid || userAccount is null)
            {
                return Content("Error - User account is invalid.");
            }

            UserAccount UserAccountToUpdate = await _context.UserAccounts.FirstOrDefaultAsync(m => m.ID == userAccount.ID).ConfigureAwait(false);

            if (null == UserAccountToUpdate)
            {
                return Content("Error - Account does not exist.");
            }

            UserAccountToUpdate.Name = userAccount.Name;
            UserAccountToUpdate.Email = userAccount.Email;
            UserAccountToUpdate.AccountType = userAccount.AccountType;
            UserAccountToUpdate.Password = userAccount.Password;

            int result = await _context.SaveChangesAsync().ConfigureAwait(false);

            if (result == 1)
            {
                return Content($"{UserAccountToUpdate.Name} has been updated!");
            }

            return Content("Error - please contact your system administrator");

        }

    }
}
