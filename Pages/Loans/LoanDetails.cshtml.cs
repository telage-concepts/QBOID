using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QBOID;
using QBOID.Models;

namespace QBOID.Pages_Loans
{
    public class LoanDetailsModel : PageModel
    {
        private readonly QBOID.ApplicationDbContext _context;

        public LoanDetailsModel(QBOID.ApplicationDbContext context)
        {
            _context = context;
        }

      public Loan Loan { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FirstOrDefaultAsync(m => m.LoanID == id);
            if (loan == null)
            {
                return NotFound();
            }
            else 
            {
                Loan = loan;
            }
            return Page();
        }
    }
}
