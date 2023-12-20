using Microsoft.AspNetCore.Mvc;
using System.Numerics;
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
        public IActionResult ProfileView(int id)
        {
            var profileList = from profile in _context.Profiles
                              where profile.Id == id
                              select profile;
            
            return View(profileList.ToList().FirstOrDefault());
        }
    }
}
