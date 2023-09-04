using System.Net.NetworkInformation;

namespace QBOID.Models;

public class Transaction
{
    public Guid TransactionID {get; set;}
    public Guid CustomerID {get; set;}
    public DateTime Date {get; set;}
    public Decimal Amount {get; set;}

}
