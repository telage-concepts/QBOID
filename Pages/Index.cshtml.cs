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
    public string requestKey;
    public string apiKey;
    public string apiSecret;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;

    }

    public StringBuilder Sha512Hash(string data)
{
    var message = Encoding.UTF8.GetBytes(data);
    var hex = new StringBuilder();
    using (var sha512 = SHA512.Create())
    {
        var hashValue = sha512.ComputeHash(message);

        foreach (byte x in hashValue)
        {
            hex.Append(string.Format("{0:x2}", x));
        }
        return hex;
    }
}
    public void OnGet()
    {
        requestKey = Guid.NewGuid().ToString();
        apiKey = "8da556fa346f73544d38961d93d64774ef62a5a235a9db8800e6138110184efef5144b015f184394e179644da37218e6d455d6627feb1bec66e1ba1d0dc1fade";
        apiSecret = "a24c87f6d0560a8910bd6d6848218e0c9eca2aa9143642108c74cc76bc6ee848dbac80a1855844ca3d64fbafa60a8cd204d8322df8a2426ddb9eab2314b20c94";

        var toenc = new StringBuilder();
        toenc.Append(apiKey);
        toenc.Append(requestKey);
        toenc.Append(apiSecret);

        var enc = this.Sha512Hash(toenc.ToString());
        
        ViewData["Authorisation"] = enc.ToString();
    }
}
