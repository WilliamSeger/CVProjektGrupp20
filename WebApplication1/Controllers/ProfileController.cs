using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public IActionResult ProfileView(int id, int id2)
        {
			var resumeList = from resume in _context.Resumes
                             where resume.ProfileId == id
							 select resume;

            ViewBag.Resume = resumeList.ToList().FirstOrDefault();

			var projectList = from project in _context.Projects
							  select project;

            ViewBag.Projects = projectList.ToList();

            if (id2 != null)
            {
                ViewBag.Class = "projectItemVisible";
            }
            else
            {
                ViewBag.Class = "projectItemInvisible";
            }

            var profileList = from profile in _context.Profiles
                              where profile.Id == id
                              select profile;
            
            return View(profileList.ToList().FirstOrDefault());
        }

        public IActionResult EditProfile(int id) 
        {
			var profileList = from profile in _context.Profiles
							  where profile.Id == id
							  select profile;

			return View(profileList.ToList().FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Profile profile) 
        {
            _context.Update(profile);
            _context.SaveChanges();

			var profileList = from oldProfile in _context.Profiles
							  where oldProfile.Id == profile.Id
							  select oldProfile;

			return RedirectToAction("EditProfile", "Profile", profileList.ToList().FirstOrDefault());
        }
        public IActionResult SearchProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchProfile(string searchString)
        {
            var profileList = from profile in _context.Profiles
                              select profile;

            if (!string.IsNullOrEmpty(searchString))
            {
                profileList = profileList.Where(profile => profile.Name.Contains(searchString));
            }

            return View(profileList.ToList());
        }
    }
}
