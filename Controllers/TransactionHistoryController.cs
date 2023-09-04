using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QBOID.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QBOID.Controllers
{
    public class TransactionHistoryQuery{
        public string Authorisation {get; set;} 
        public string RequestKey {get; set;}
        public string Email {set; get;}
        public string? PhoneNumber{get; set;}
    }
    public class TransactionHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TransactionHistoryController(ApplicationDbContext context){
            _context = context;
        }
        [HttpPost("")]
        public IActionResult Index(TransactionHistoryQuery transactionHistoryQuery)
        {
            string ExpectedAuthorisation = Sha512.Sha512AuthHash(transactionHistoryQuery.RequestKey).ToString();
            if(ExpectedAuthorisation == transactionHistoryQuery.Authorisation){
                var Customer = _context.Customers
                .Include(c => c.Transactions)
                .First(c => c.Email == transactionHistoryQuery.Email);
                var transactions = Customer.Transactions;
                return Ok(transactions);
            }
            return NotFound();
        }
    }
}