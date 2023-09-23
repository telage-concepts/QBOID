using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QBOID.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QBOID.Controllers
{
    public class DisbursementAccountQuery{
        public string? Authorisation {get; set;} 
        public string? RequestKey {get; set;}
        public string? CustomerId {get; set;}
        public string? ApiKey { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class GetDisbursementAccount : Controller
    {
        private readonly ApplicationDbContext _context;
        public GetDisbursementAccount(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Index(DisbursementAccountQuery query)
        {
            string ExpectedAuthorisation = Sha512.Sha512AuthHash(query.RequestKey!).ToString();
            if(ExpectedAuthorisation == query.Authorisation){
                var Customer = _context.Customers!
                .First(c => c.Email == query.CustomerId);
                return Ok(new {
                    accountName = Customer.BankAccountName,
                    accountNumber = Customer.BankAccountNumber,
                    bankCode = Customer.BankCode
                });
            }
            return NotFound();
        }
    }
}