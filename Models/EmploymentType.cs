namespace QBOID.Models;
using System.ComponentModel.DataAnnotations;

public enum EmploymentType
{
    Employed = 1,
    [Display(Name = "Self Employed")]
    SelfEmployed = 2,
    Contract = 3,
    [Display(Name = "Part Time")]
    PartTime = 4,
    Unemployed = 5
}
