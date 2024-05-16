using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using Microsoft.AspNetCore.Mvc;
using QBOID.Models;

namespace QBOID.Pages
{
    public class responseMessage{
        public bool success { get; set; }
        public string? data { get; set; }
        public string? message{ get; set; }
    }
    public class RedirectUrlModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Guid _LoanId;
        public string apiKey = "MDUzMTkxN2ItMjliOS00MmVmLWI5MDEtNGQ5YTliNDZiMzIy";
        public string apiSecret = "YTBjYmE1ZGYtNjQ1ZC00YzU1LWI2NmEtYzYzYjRjZTdjMTUy";
        public string? requestKey;

        public RedirectUrlModel(ApplicationDbContext context){
            _context = context;
        }

        public IActionResult OnGet(Guid? LoanId)
        {
            if(LoanId == null){
                return NotFound();
            }
            _LoanId = (Guid)LoanId;
            requestKey = Guid.NewGuid().ToString();

            ViewData["Authorisation"] = Sha512.Sha512AuthHash(requestKey).ToString();
            
            var client = new RestClient("https://devembed.azurewebsites.net/embed/webhook/request-loan-status");

            var args = new {
                LoanId = _LoanId.ToString(),
                ApiKey = apiKey,
                RequestKey = requestKey,
                Authorisation = Sha512.Sha512AuthHash(requestKey).ToString()
            };
            var request = new RestRequest();
            request.AddJsonBody(args);

            var response = client.Post(request);
            var responseJson = JsonConvert.DeserializeObject<responseMessage>(response.Content!.ToString());
            Console.WriteLine(response.Content.ToString());
            Console.WriteLine(responseJson);
            var Loan = _context.Loans!.FirstOrDefault(l=> l.LoanID == _LoanId);
            Loan!.Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), responseJson!.data!, true);
            _context.Loans!.Update(Loan);
            _context.SaveChanges();

            if(Loan.Status == LoanStatus.Review || Loan.Status == LoanStatus.Active){
                return RedirectToPage("LoanApplicationSuccess");
            }else{
                return RedirectToPage("LoanApplicationFailure");
            }

        }
    }
}

// bea4baab-7627-4ba1-a6b5-e6d761c81d3c
