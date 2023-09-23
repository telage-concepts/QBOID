using System;

namespace QBOID.Models;

public class PaymentSchedule
{
    public Guid PaymentScheduleID { get; set; }
    public DateTime DueDate { get; set; }
    public Decimal Amount { get; set;}
    public Guid MIMScheduleId{ get; set; }
}
