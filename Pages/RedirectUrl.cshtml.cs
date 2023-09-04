using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using Microsoft.AspNetCore.Mvc;

namespace QBOID.Pages
{
    public class responseMessage{
        public bool success {get; set;}
        public string data {get; set;}
        public string message{get; set;}
    }
    public class RedirectUrlModel : PageModel
    {
        public Guid _LoanId;
        public string apiKey = "OWY2NDUyZjUtYTQ4MC00NjA1LWI3NDctODRmN2QwYjFlNjli";
        public string apiSecret = "MjM1MTg3OWMtOThmYS00ZDY1LTlmMzQtMzEyMTJmNWQxOGQz";
        public string requestKey;

        public async Task<IActionResult> OnGetAsync(Guid? LoanId)
        {
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
            var responseJson = JsonConvert.DeserializeObject<responseMessage>(response.Content.ToString());
            Console.WriteLine(response.Content.ToString());
            Console.WriteLine(responseJson);
            if(responseJson.success){
                return RedirectToPage("LoanApplicationSuccess");
            }else{
                return RedirectToPage("LoanApplicationSuccess");
            }

        }
    }
}
