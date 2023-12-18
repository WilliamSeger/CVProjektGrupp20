using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    
    public class ResumeController : Controller
    {
        public ResumeController() { }
        public IActionResult Search()
        {

            return View();
        }
    }
}
