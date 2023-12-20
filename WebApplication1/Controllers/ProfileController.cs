using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProfileController : Controller
    {
        CVContext _context;
        public ProfileController(CVContext context) 
        {
            _context = context;
        }
        public IActionResult ProfileView()
        {
            var profileList = from profile in _context.Profiles
                             select profile;

            return View(profileList.ToList());
        }
    }
}
