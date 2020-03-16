using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamOrganiser.Models.Account;

namespace TeamOrganiser.Controllers
{
    public class EditAccountController : Controller
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{useraccountid}")]
        public async Task<UserAccount> GetUserAccount([FromRoute]int useraccountid)
        {
            UserAccount UserAccount = new UserAccount();
            UserAccount = await _context.UserAccount.FindAsync(useraccountid);

            return UserAccount;
        }
    }
}