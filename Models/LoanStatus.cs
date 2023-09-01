namespace QBOID.Models;

public enum LoanStatus
{
    None = 0,
    Application,
    Review,
    Active,
    Expired,
    InArrears,
    Bad,
    Settled,
    Cancelled
}
