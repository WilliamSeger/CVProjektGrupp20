using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProfileController : BaseController
    {
        CVContext _context;
        public ProfileController(CVContext context, UserManager<User> userManager) : base(context, userManager)
        {
            _context = context;
        }
        public IActionResult ProfileView(int id, int id2)
        {
			var resumeList = from resume in _context.Resumes
                             where resume.ProfileId == id
							 select resume;
            if (!resumeList.IsNullOrEmpty())
            {
				ViewBag.Resume = resumeList.ToList().FirstOrDefault();
			}
            else
            {
                ViewBag.Resume = new Resume();
            }
      

			var projectList = from project in _context.Projects
							  select project;

            if (!projectList.IsNullOrEmpty())
            {
                ViewBag.Projects = projectList.ToList();
            }
            else
            {
                ViewBag.Projects = new List<Project>();
            }
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

        public IActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(CreateProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                Profile profile = new Profile();
                profile.Name = profileViewModel.Name;
                profile.Adress = profileViewModel.Adress;
                profile.IsPrivate = profileViewModel.IsPrivate;
                string userName = User.Identity.Name;
                var result = from user in _context.Users
                             where user.UserName == userName
                             select user;
                User currentUser = result.ToList()[0];
                profile.UserId = currentUser.Id;
                profile.User = currentUser;
                profile.Email = new List<string>();
                profile.Email.Add(profileViewModel.Email);
                _context.Add(profile);
                _context.SaveChanges();
				return RedirectToAction("ProfileView", "Profile", profile);
			}
            else
            {
                return View();
            }
        }
    }
}
