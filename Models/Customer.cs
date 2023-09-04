namespace QBOID.Models;

public class Customer
{
    public Guid CustomerID {get; set;}
    public string Email {get; set;}
    public ICollection<Transaction>? Transactions {get; set;}
}
