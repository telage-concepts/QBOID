﻿namespace QBOID.Models;

public class GenerateTransactionHistory
{
    private static ApplicationDbContext? _context;
    public static void GenerateHistory(ApplicationDbContext context, string Email){
        _context = context;
        if(!CustomerExists(_context, Email)){
            Customer Customer = new Customer{
                Email = Email
            };
            _context.Customers!.Add(Customer);
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
            

            for(int i = 0; i < 10 ; i++){
                date = date.AddMonths(-1);
                Random r = new Random();
                Transaction Transaction = new Transaction{
                    CustomerID = Customer.CustomerID,
                    Date = date,
                    Amount = (Decimal)r.NextDouble() * 1000000
                };
                _context.Transactions!.Add(Transaction);
            }

            _context.SaveChanges();
        }
        
    }
    private static bool CustomerExists(ApplicationDbContext context, string Email){
        _context = context;
        return (_context.Customers?.Any(e => e.Email == Email)).GetValueOrDefault();
    }
}
