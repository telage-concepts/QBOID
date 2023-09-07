using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QBOID.Models;
using QBOID;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QBOID.Controllers
{
    public class ActivityUpdateQuery
    {
        public string? ApiKey {get; set;}
        public string? Authorisation {get; set;}
        public string? RequestKey {get; set;}
        public string? MimLoanId {get; set;}
        public string? Status {get; set;}
        public Guid LoanId {get; set;}
        public string? Activity {get; set;}
    }
    
    [ApiController]
    [Route("[controller]")]
    public class ActivityCallbackController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ActivityCallbackController(ApplicationDbContext context){
            _context = context;
        }
        [HttpPost]
        public IActionResult Index(ActivityUpdateQuery activityUpdateQuery)
        {
            if(activityUpdateQuery.RequestKey == null || activityUpdateQuery.ApiKey == null){
                return NotFound();
            }
            string ExpectedAuthorisation = Sha512.Sha512AuthHash(activityUpdateQuery.RequestKey, activityUpdateQuery.ApiKey).ToString();
            if(ExpectedAuthorisation == activityUpdateQuery.Authorisation){
                var Loan = _context.Loans!.First(c => c.LoanID == activityUpdateQuery.LoanId);

                Loan.Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), activityUpdateQuery.Status!);
                Loan.Activity = (LoanActivity)Enum.Parse(typeof(LoanActivity), activityUpdateQuery.Activity!);

                _context.Update(Loan);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}