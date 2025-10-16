using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Lab3.Controllers
{
    public class LabController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult Welcome(string name, int id = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["id"] = id;
            return View();
        }
    }
}
