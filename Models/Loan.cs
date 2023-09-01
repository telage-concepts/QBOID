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
    public LoanStatus Status {get; set;} = LoanStatus.None;
    public LoanActivity Activity {get; set;} =  LoanActivity.None;
    public Guid EmployerRecordID{get; set;}
    public EmployerRecord EmployerRecord{get; set;}
    public Guid MimLoanId{get; set;}
}
