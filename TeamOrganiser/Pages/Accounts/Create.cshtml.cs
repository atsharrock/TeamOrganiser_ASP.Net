using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamOrganiser.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace TeamOrganiser
{
    public class CreateAccountsModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public CreateAccountsModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnPostAsync(UserAccount UserAccount)
        {
            if (!ModelState.IsValid)
            {
                return Content("Error - Model state is invalid.");
            }

            var newUserAccount = new UserAccount();

            if (UserAccount != null)
            {
                newUserAccount.Name = UserAccount.Name;
                newUserAccount.Email = UserAccount.Email;
                newUserAccount.Password = EncryptPassword(newUserAccount, UserAccount.Password);
                newUserAccount.AccountType = UserAccount.AccountType;

                _context.UserAccount.Add(newUserAccount);
                await _context.SaveChangesAsync().ConfigureAwait(true);

                return Content(newUserAccount.Name + " has been created!");
            }

            return Content("Error - Could not create User Account.");
        }

        private string EncryptPassword(UserAccount account, string password)
        {
            var passwordHasher = new PasswordHasher<UserAccount>();
            return passwordHasher.HashPassword(account, password);
        }
    }
}
