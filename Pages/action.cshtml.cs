using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using QBOID.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
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
        public string EmploymentDateString;
        public string NextPayDayString;
        public string requestKey;
        public string apiKey = "a24c87f6d0560a8910bd6d6848218e0c9eca2aa9143642108c74cc76bc6ee848dbac80a1855844ca3d64fbafa60a8cd204d8322df8a2426ddb9eab2314b20c94";
        public string apiSecret = "8da556fa346f73544d38961d93d64774ef62a5a235a9db8800e6138110184efef5144b015f184394e179644da37218e6d455d6627feb1bec66e1ba1d0dc1fade";


        public StringBuilder Sha512Hash(string data)
    {
        var message = Encoding.UTF8.GetBytes(data);
        var hex = new StringBuilder();
        using (var sha512 = SHA512.Create())
        {
            var hashValue = sha512.ComputeHash(message);

            foreach (byte x in hashValue)
            {
                hex.Append(string.Format("{0:x2}", x));
            }
            return hex;
        }
    }

        [BindProperty]
        public Loan _Loan {get; set;}
        public IActionResult OnGet(Loan Loan)
        {
            if(Loan.LoanID == null){
                return NotFound();
            }
            requestKey = Guid.NewGuid().ToString();

            var toenc = new StringBuilder();
            toenc.Append(apiKey);
            toenc.Append(requestKey);
            toenc.Append(apiSecret);

            var enc = this.Sha512Hash(toenc.ToString());
            
            ViewData["Authorisation"] = enc.ToString();

            var formatInfo =new CultureInfo("ja-JP");
            // formatInfo.DateSeparator ="-";
            _Loan = _context.Loans.Include(l => l.EmployerRecord).First(l => l.LoanID == Loan.LoanID);
            EmployerSector =  (int)_Loan.EmployerRecord.EmployerSector;
            EmploymentDuration = (int)_Loan.EmployerRecord.EmploymentDuration;
            EmploymentType = (int)_Loan.EmployerRecord.EmploymentType;
            IncomeReceiptMode = (int)_Loan.EmployerRecord.IncomeReceiptMode;
            SalaryFrequency = (int)_Loan.EmployerRecord.SalaryFrequency;
            EmploymentDate = _Loan.EmployerRecord.EmploymentDate;
            NextPayDay = _Loan.EmployerRecord.NextPayDay;
            EmploymentDateString = EmploymentDate.ToString("d", formatInfo);
            NextPayDayString = NextPayDay.ToString("d", formatInfo);
            return Page();
        }

        public IActionResult OnPost(string authorisation, string requestKey, string mimLoanId,
         string status,  string loanId, string activity){
        var toenc = new StringBuilder();
            toenc.Append(apiKey);
            toenc.Append(requestKey);
            toenc.Append(apiSecret);

            var expectedAuthorisation = this.Sha512Hash(toenc.ToString());

            if(expectedAuthorisation.ToString() != authorisation){
                return Forbid();
            }
            return Page();
        }
    }
}
