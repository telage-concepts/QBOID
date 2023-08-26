namespace QBOID.Models;
using System.ComponentModel.DataAnnotations;

public enum EmployerSector
{
    Public = 1,
    Private = 2,
    Banking = 3,
    [Display(Name="Oil and Gas")]
    OilAndGas = 4,
    FMCG = 5,
    Construction = 6,
    Manufacturing = 7,
    Other = 8
}
