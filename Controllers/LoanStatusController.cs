using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QBOID.Controllers
{
    public class LoanStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}