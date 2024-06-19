using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using QBOID.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using QBOID;

namespace QBOID.Pages
{


    public class actionModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public actionModel(ApplicationDbContext context){
            _context = context;
        }

        public int EmployerSector;
        public int EmploymentType;
        public int IncomeReceiptMode;
        public int EmploymentDuration;
        public int SalaryFrequency;
        public DateTime EmploymentDate;
        public DateTime NextPayDay;
        public string? EmploymentDateString;
        public string? NextPayDayString;
        public string? requestKey;
        public string apiKey = "MDUzMTkxN2ItMjliOS00MmVmLWI5MDEtNGQ5YTliNDZiMzIy";
        public string apiSecret = "YTBjYmE1ZGYtNjQ1ZC00YzU1LWI2NmEtYzYzYjRjZTdjMTUy";



        [BindProperty]
        public Loan? _Loan {get; set;}
        public IActionResult OnGet(Loan Loan)
        {
            if(Loan == null){
                return NotFound();
            }
            requestKey = Guid.NewGuid().ToString();

            var enc = Sha512.Sha512AuthHash(requestKey);
            
            ViewData["Authorisation"] = enc.ToString();

            var formatInfo =new CultureInfo("ja-JP");
            // formatInfo.DateSeparator ="-";
            _Loan = _context.Loans!.Include(l => l.EmployerRecord).First(l => l.LoanID == Loan.LoanID);
            EmployerSector =  (int)_Loan!.EmployerRecord!.EmployerSector;
            EmploymentDuration = (int)_Loan.EmployerRecord.EmploymentDuration;
            EmploymentType = (int)_Loan.EmployerRecord.EmploymentType;
            IncomeReceiptMode = (int)_Loan.EmployerRecord.IncomeReceiptMode;
            SalaryFrequency = (int)_Loan.EmployerRecord.SalaryFrequency;
            EmploymentDate = _Loan.EmployerRecord.EmploymentDate;
            NextPayDay = _Loan.EmployerRecord.NextPayDay;
            EmploymentDateString = EmploymentDate.ToString("yyyy-MM-ddTHH:mm:ss");
            NextPayDayString = NextPayDay.ToString("yyyy-MM-ddTHH:mm:ss");
            return Page();
        }

        public IActionResult OnPost(string authorisation, string requestKey, string mimLoanId,
         string status,  string loanId, string activity){

            var expectedAuthorisation = Sha512.Sha512AuthHash(requestKey);

            if(expectedAuthorisation.ToString() != authorisation){
                return Forbid();
            }

            var Loan = _context.Loans!.First(l => l.LoanID == new Guid(loanId));
            Loan.MimLoanId = new Guid(mimLoanId);
            Loan.Status = (LoanStatus)int.Parse(status);
            Loan.Activity = (LoanActivity)int.Parse(activity);
            _context.Loans!.Update(Loan);
            _context.SaveChanges();

            return RedirectToPage("Loans/LoanDetails", new {id = Loan.LoanID});
        }
    }
}
