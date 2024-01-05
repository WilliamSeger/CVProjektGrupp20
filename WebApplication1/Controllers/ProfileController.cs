using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System.Numerics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProfileController : Controller
    {
        CVContext _context;
		private UserManager<User> userManager;

		public ProfileController(CVContext context, UserManager<User> userManager) 
        {
            _context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyProfileView()
        {
            //Fetches the profile id of the current user through UserManager. This then provides the profileview of the user.
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
            Profile userProfile = new Profile();
            if (!profileQuery.IsNullOrEmpty())
            {
                userProfile = profileQuery.ToList().First();
            }


            return RedirectToAction("ProfileView", "Profile", new { userProfile.Id });
		    }

        public IActionResult ProfileView(int id)
        {
            //fetches the profile, resume and projects belonging to the id provided as a parameter. 
            //The resume and projects are put in seperate viewbags and the profile is sent to the view. 
            var userName = User.Identity.Name;

            var currentUser = from user in _context.Users 
                              where user.UserName == userName
                              select user;
            if (currentUser.Any())
            {
				ViewBag.UserId = currentUser.ToList().FirstOrDefault().Id;
			}

            var resumeList = from resume in _context.Resumes
                             where resume.ProfileId == id
							 select resume;
            if (!resumeList.IsNullOrEmpty())
            {
				ViewBag.Resume = resumeList.ToList().FirstOrDefault();
			}
            else
            {
                ViewBag.Resume = null;
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

            var profileList = from profile in _context.Profiles
                              where profile.Id == id
                              select profile;

            Profile userProfile = new Profile();
            if (!profileList.IsNullOrEmpty())
            {
                userProfile = profileList.ToList().First();
            }

            return View(userProfile);
        }

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> EditProfile() 
        {
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			Profile userProfile = profileQuery.FirstOrDefault();
			ViewBag.Profile = userProfile;

			return View(userProfile);
		}

		[Authorize]
		[HttpPost]
        public IActionResult Edit(Profile userProfile, int id) 
        {
            var profileQuery = from profile in _context.Profiles
                               where profile.Id == id
                               select profile;
            Profile currentProfile = profileQuery.FirstOrDefault();

			if (userProfile.Name != null)
			{
				currentProfile.Name = userProfile.Name;
			}
			if (userProfile.Email != null)
			{
				currentProfile.Email = userProfile.Email;
			}
			if (userProfile.Adress != null)
			{
				currentProfile.Adress = userProfile.Adress;
			}
			currentProfile.IsPrivate = userProfile.IsPrivate;

			var profileList = from oldProfile in _context.Profiles
							  where oldProfile.Id == currentProfile.Id
							  select oldProfile;

			if (currentProfile != null)
            {
                _context.Update(currentProfile);
                _context.SaveChanges();
				TempData["AlertMessage"] = "Profile updated succesfully";

				return RedirectToAction("MyProfileView", "Profile");
			}

			return RedirectToAction("EditProfile", "Profile");
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
                profile.ProfilePicturePath = "";
                profile.Adress = profileViewModel.Adress;
                profile.IsPrivate = profileViewModel.IsPrivate;
                profile.RecievedAnonymousMessages = new List<AnonymousMessage>();
                profile.ParticipatesIn = new List<ParticipatesIn>();
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
				TempData["AlertMessage"] = "Profile created succesfully";
				return RedirectToAction("ProfileView", "Profile", profile);
			}
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult UploadProfilePicture()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            //Skapa en filepath till där bilden ska sparas
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profiles");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            //Spara med filestream
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //Hämta profilen som ska kopplas till bilden
            User currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            var profileQuery = from profile in _context.Profiles
                               where profile.UserId == currentUser.Id
                               select profile;
            Profile userProfile = new Profile();
            if (!profileQuery.IsNullOrEmpty())
            {
                userProfile = profileQuery.ToList().First();
                userProfile.ProfilePicturePath = fileName;
                _context.Update(userProfile);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Profile picture updated succesfully";
            }

            return RedirectToAction("MyProfileView");
        }

    }
}
