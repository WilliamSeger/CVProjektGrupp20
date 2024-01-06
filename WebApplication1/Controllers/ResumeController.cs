using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Controllers
{

    public class ResumeController : Controller
    {
        private CVContext _context;
        private UserManager<User> userManager;
        public ResumeController(CVContext context, UserManager<User> userManager) 
        { 
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult Search()
		{
			//HomepageView fetches all resumes and filters out public ones
			var profileIdList = from profile in _context.Profiles
							  where profile.IsPrivate == false
							  select profile.Id;

			var resumeList = from resume in _context.Resumes
                             select resume;

			List<Resume> publicResumeList = new List<Resume>();

            var projectList = from project in _context.Projects
                              orderby project.Created descending
                              select project;
            if(!projectList.IsNullOrEmpty())
            {
                ViewBag.LatestProject = projectList.FirstOrDefault();
            }

			foreach (var resume in resumeList.ToList())
			{
				if (profileIdList.ToList().Contains(resume.ProfileId))
				{
					publicResumeList.Add(resume);
				}
			}

			ViewBag.PublicResumes = publicResumeList;

			return View(resumeList.ToList());
        }
		
		public async Task<IActionResult> EditResume()
		{
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            var profileQuery = from profile in _context.Profiles
                               where profile.UserId == user.Id
                               select profile;
            Profile userProfile = profileQuery.FirstOrDefault();
            var resumeList = from resume in _context.Resumes
							  where resume.ProfileId == userProfile.Id
							  select resume;
			Resume userResume = resumeList.FirstOrDefault();
			ViewBag.Resume = userResume;

			return View(userResume);
		}

		[HttpPost]
		public IActionResult Edit(Resume userResume, int id)
		{
			var resumeQuery = _context.Resumes.Where(resume => resume.Id == id);
			Resume currentResume = resumeQuery.FirstOrDefault();

            if (userResume.Qualification != null)
            {
                currentResume.Qualification = userResume.Qualification;
            }
            if (userResume.Phonenumber != null)
            {
                currentResume.Phonenumber = userResume.Phonenumber;
            }
            if (userResume.Education != null)
            {
                currentResume.Education = userResume.Education;
            }
            if (userResume.Experiences != null)
            {
                currentResume.Experiences = userResume.Experiences;
            }

            if (currentResume != null)
            {
                _context.Update(currentResume);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Resume updated succesfully";

                return RedirectToAction("MyProfileView", "Profile");
            }
            
			var resumeList = from oldResume in _context.Resumes
							  where oldResume.Id == currentResume.Id
							  select oldResume;

			return RedirectToAction("EditResume", "Resume", resumeList.ToList().FirstOrDefault());
		}

		[Authorize]
		[HttpPost]
		public IActionResult Delete(int id)
		{
			//Deletes the resume that corresponds to the ProfileId and updates the database. 
			try { 
				var resumesToDelete = _context.Resumes.Where(r => r.ProfileId == id);
				foreach (var resume in resumesToDelete)
				{
					_context.Resumes.Remove(resume);
				}

				_context.SaveChanges();

				return RedirectToAction("ProfileView", "Profile", new { id });
			}
			catch (Exception ex)
			{
                Console.WriteLine($"An error occurred: {ex.Message}");

                return View("Error");
            }
        }
		[Authorize]
		[HttpPost]
		public IActionResult AddNew(Resume resume)
		{
			//Creates a Resume using the values provided by the inputs. 
            var resumeToRemove = from resumes in _context.Resumes
                                 where resumes.ProfileId == resume.ProfileId
                                 select resumes;
            _context.Resumes.Remove(resumeToRemove.FirstOrDefault());
            _context.Resumes.Add(resume);
			_context.SaveChanges();

			return RedirectToAction("ProfileView", "Profile", new { id = resume.ProfileId });
		}

		[Authorize]
		[HttpPost]
		public IActionResult CreateResume(int id)
		{
			//Creates a new blank resume and sends it to the view.
			//The lists contains dummy items because the input fields in the view needs items in the list to attach to.
            var newResume = new Resume
            {
                ProfileId = id,
                Qualification = new List<string> { "" },
                Phonenumber = new List<string> { "" },
                Education = new List<string> { "" },
                Experiences = new List<string> { "" }
            };

            var resumeList = from resumes in _context.Resumes
                             where resumes.ProfileId == id
                             select resumes;
            if (!resumeList.Any())
            {
                _context.Resumes.Add(newResume);
                _context.SaveChanges();
            }
            return View(newResume);
		}
        [Authorize]
        public IActionResult CreateResumeOverload(int id)
        {
            //Creates a new blank resume and sends it to the view.
            //The lists contains dummy items because the input fields in the view needs items in the list to attach to.
            var resumeJson = TempData["ResumeData"] as string;
            var resume = JsonSerializer.Deserialize<Resume>(resumeJson);
            return View("CreateResume", resume);
        }
        public IActionResult EditResumeOverload(int id)
        {
            //Creates a new blank resume and sends it to the view.
            //The lists contains dummy items because the input fields in the view needs items in the list to attach to.
            var resumeJson = TempData["ResumeData"] as string;
            var resume = JsonSerializer.Deserialize<Resume>(resumeJson);
            return View("EditResume", resume);
        }

        [HttpPost]
        public IActionResult addItem(int id, int caseId, string method, Resume resume)
		{
			var resumeList = from resumes in _context.Resumes
							 where resumes.ProfileId == resume.ProfileId
							 select resumes;
			Resume currentResume = resumeList.ToList().FirstOrDefault();

			switch (caseId)
			{
				case 1:
					resume.Qualification.Add("");
                    currentResume.Qualification = resume.Qualification;
					break;
				case 2:
					resume.Phonenumber.Add("");
                    currentResume.Phonenumber = resume.Phonenumber;
                    break;
                case 3: 
					resume.Education.Add("");
                    currentResume.Education = resume.Education;
                    break;
                case 4: 
					resume.Experiences.Add("");
                    currentResume.Experiences = resume.Experiences;
                    break;
            }

            _context.Update(currentResume);
            _context.SaveChanges();

            string resumeJson = JsonSerializer.Serialize(resume);
            TempData["ResumeData"] = resumeJson;

            if (method.Equals("create"))
            {
                return RedirectToAction("CreateResumeOverload", "Resume", new { id });
            }
            else
            {
                return RedirectToAction("EditResumeOverload", "Resume", new { id });
            }
        }
        [HttpPost]
        public IActionResult RemoveField(int caseId, int profId, string method, Resume resume)
        {
            switch (caseId)
            {
                case 1:
                    resume.Qualification.RemoveAt(resume.Qualification.Count-1);
                    break;
                case 2:
                    resume.Phonenumber.RemoveAt(resume.Phonenumber.Count-1);
                    break;
                case 3:
                    resume.Education.RemoveAt(resume.Education.Count-1);
                    break;
                case 4:
                    resume.Experiences.RemoveAt(resume.Experiences.Count-1);
                    break;
            }

			_context.Update(resume);
            _context.SaveChanges();

            string resumeJson = JsonSerializer.Serialize(resume);
            TempData["ResumeData"] = resumeJson;

			if (method.Equals("create"))
			{
				return RedirectToAction("CreateResumeOverload", "Resume", new { profId });
			}
			else
			{
				return RedirectToAction("EditResumeOverload", "Resume", new { profId });
			}
        }
    }
}
