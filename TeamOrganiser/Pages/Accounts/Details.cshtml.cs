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
    public class DetailsModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public DetailsModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAccount = await _context.UserAccount.FirstOrDefaultAsync(m => m.ID == id);

            if (UserAccount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
