using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QBOID.Models;
using System.Security.Cryptography;
using System.Text;

namespace QBOID.Pages;

public class IndexModel : PageModel
{
    public Loan Loan;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;

    }

    public void OnGet()
    {
    }
}
