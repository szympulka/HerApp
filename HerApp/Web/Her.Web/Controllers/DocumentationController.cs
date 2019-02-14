using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Her.Web.Controllers
{
    public class DocumentationController : Controller
    {
        public IActionResult Version(double version = 1.0)
        {
            return View("1v0");
        }
    }
}