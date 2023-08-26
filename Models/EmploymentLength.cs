namespace QBOID.Models;
using System.ComponentModel.DataAnnotations;


public enum EmploymentLength
{
    [Display(Name = "Less Than One")]
    LessThanOne = 0,
    One = 1,
    Two =  2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    [Display(Name = "Ten+ ")]
    TenPlus = 11
}
