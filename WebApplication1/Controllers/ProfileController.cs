using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Fetches the logged in users connected profile
        public async Task<IActionResult> MyProfileView()
        {
            try
            {
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
            catch(DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "Connected profile could not be fetched.");
            }
        }

        //Sends the user the the designated profile view along with resumes, projects etc as ViewBag properties
        public IActionResult ProfileView(int id)
        {
            try
            {
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

                var projectList = from participant in _context.Participants
                                  where participant.ProfileId == id
                                  select participant;

                if (!projectList.IsNullOrEmpty())
                {
                    ViewBag.Projects = projectList.ToList();
                }
                else
                {
                    ViewBag.Projects = new List<ParticipatesIn>();
                }

                var ownedProjectList = from project in _context.Projects
                                       where project.ProjectOwnerId == id
                                       select project;

                if (!ownedProjectList.IsNullOrEmpty())
                {
                    ViewBag.OwnedProjects = ownedProjectList.ToList();
                }
                else
                {
                    ViewBag.OwnedProjects = new List<Project>();
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
            catch (DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "Profile could not be fetched.");
            }
        }

        //Takes the user to the Edit profile view
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> EditProfile() 
        {
            try
            {
                User user = await userManager.FindByNameAsync(User.Identity.Name);
                var profileQuery = from profile in _context.Profiles
                                   where profile.UserId == user.Id
                                   select profile;
                Profile userProfile = profileQuery.FirstOrDefault();
                ViewBag.Profile = userProfile;

                return View(userProfile);
            }
            catch (DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "User profile could not be fetched.");
            }
        }

        //Lets the user edit his/her profile
		[Authorize]
		[HttpPost]
        public IActionResult Edit(Profile userProfile, int id) 
        {
            try
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
            catch (DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "User profile could not be fetched.");
            }
        }

        //Returns the Serach Profile view
        public IActionResult SearchProfile()
        {
            return View();
        }

        //Lets the user search for profiles by username
        [HttpGet]
        public IActionResult SearchProfile(string searchString)
        {
            try
            {
                var profileList = from profile in _context.Profiles
                                  select profile;

                if (!string.IsNullOrEmpty(searchString))
                {
                    profileList = profileList.Where(profile => profile.Name.Contains(searchString));
                }

                return View(profileList.ToList());
            }
            catch (DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "Profiles could not be fetched.");
            }
        }

        //Takes the user to the create profile view
        public IActionResult CreateProfile()
        {
            return View();
        }

        //Lets the user create a profile
        [HttpPost]
        public IActionResult CreateProfile(CreateProfileViewModel profileViewModel)
        {
            try
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
            catch (DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "New profile data could not be fetched.");
            }
        }

        //Takes the user to the Upload profile picture view
        [Authorize]
        [HttpGet]
        public IActionResult UploadProfilePicture()
        {
            return View();
        }

        //Lets the user upload and store a profile picture
        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Invalid file.");
                }

                //Creates a filepath to where the picture is to be stored
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profiles");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                //Save with Filestream
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                //Fetch the profile connected to the user
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
            catch (DbUpdateException dbex)
            {
                return View("Views/Error/ErrorView.cshtml", "Database problem. Check your connection.");
            }
            catch (Exception ex)
            {
                return View("Views/Error/ErrorView.cshtml", "New profile picture could not be uploaded.");
            }
        }
    }
}
