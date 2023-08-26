using System;

namespace QBOID.Models;

public class Loan
{
    public Guid LoanID {get; set;}
    public string Email{get; set;}
    public string PhoneNumber{get; set;}
    public string BankVerificationNumber{get; set;}
    public string BankCode{get; set;}
    public string BankAccountNumber{get; set;}
    public EmployeeRecord EmployeeRecord{get; set;}
}
