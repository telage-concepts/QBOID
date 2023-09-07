using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QBOID.Models;
using System.Security.Cryptography;
using System.Text;

namespace QBOID.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Loan Loan{get; set;} = default!;
    private readonly ILogger<IndexModel> _logger;
    private readonly QBOID.ApplicationDbContext _context;
    public string? requestKey;
    public string apiKey = "OWY2NDUyZjUtYTQ4MC00NjA1LWI3NDctODRmN2QwYjFlNjli";
    public string apiSecret = "MjM1MTg3OWMtOThmYS00ZDY1LTlmMzQtMzEyMTJmNWQxOGQz";
    public IndexModel(ILogger<IndexModel> logger, QBOID.ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
            requestKey = Guid.NewGuid().ToString();
            var enc = Sha512.Sha512AuthHash(requestKey);
            ViewData["Authorisation"] = enc.ToString();
    }

    public IActionResult OnPost(Loan Loan){
        if (!ModelState.IsValid || _context.Loans == null || Loan == null){
            Console.WriteLine(string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)));
            return Page();
        }
        if(!_context.Loans.Contains<Loan>(Loan)){
            _context.Loans.Add(Loan);
            _context.SaveChanges();
        }
        var Loant = _context.Loans.First(i => i.LoanID == Loan.LoanID);
        GenerateTransactionHistory.GenerateHistory(_context, Loant.Email!);

        return RedirectToPage("action", Loant);
    }
}
