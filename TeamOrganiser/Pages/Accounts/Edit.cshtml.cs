using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<IActionResult> OnPostAsync(UserAccount UserAccount)
        {
            if (!ModelState.IsValid || UserAccount is null)
            {
                return Content("Error - User account is invalid");
            }

            var userAccountToUpdate = await _context.UserAccount.FindAsync(UserAccount.ID);

            userAccountToUpdate.Name = UserAccount.Name;
            userAccountToUpdate.Email = UserAccount.Email;
            userAccountToUpdate.AccountType = UserAccount.AccountType;
            userAccountToUpdate.Password = UserAccount.Password;

            if (UserAccount.ID == userAccountToUpdate.ID) {
                int result = await _context.SaveChangesAsync().ConfigureAwait(false);

                if (result == 1)
                {
                    return Content($"{userAccountToUpdate.Name} has been updated!");
                }
            }

            return Content("Error - please contact your system administrator");

        }

    }
}
