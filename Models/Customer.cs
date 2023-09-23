namespace QBOID.Models;

public class Customer
{
    public Guid CustomerID {get; set;}
    public string? Email {get; set;}
    public string? BankAccountNumber { get; set; }
    public string? BankAccountName { get; set; }
    public string? BankCode { get; set; } = "200";
    public ICollection<Transaction>? Transactions {get; set;}
}
