using System;
using System.ComponentModel.DataAnnotations;

namespace QBOID.Models;

public class EmployerRecord
{
    public Guid EmployerRecordID{get; set;}
    public EmployerSector EmployerSector {get; set;}
    public EmploymentType EmploymentType {get; set;}
    public string EmployerName {get; set;}
    public string EmployerAddress{get; set;}
    public string City {get; set;}
    public string State{get; set;}
    public string EmployerPhone{get; set;}

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
    public DateTime EmploymentDate{get; set;}
    public Decimal NetMonthlyIncome{get; set;}
    public EmploymentLength EmploymentDuration {get; set;}

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true, HtmlEncode = true)]
    public DateTime NextPayDay{get; set;}
    public int ToleranceDays { get; set;}
    public Decimal TotalMonthlyExpense{ get; set; }
    public PayFrequency SalaryFrequency{get; set;}
    public IncomeReceiptMode IncomeReceiptMode{get; set;}
}
