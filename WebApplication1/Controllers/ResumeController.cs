using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

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
                Qualification = new List<string> { "Item 1" },
                Phonenumber = new List<string> { "Item 1" },
                Education = new List<string> { "Item 1" },
                Experiences = new List<string> { "Item 1" }
            };
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
		[HttpPost]
        public IActionResult addItem(int id, int caseId, Resume resume)
		{
			switch (caseId)
			{
				case 1:
					resume.Qualification.Add("item");
					break;
				case 2:
					resume.Phonenumber.Add("item");
                    break;
                case 3: 
					resume.Education.Add("item");
                    break;
                case 4: 
					resume.Experiences.Add("item");
                    break;
            }
            string resumeJson = JsonSerializer.Serialize(resume);
            TempData["ResumeData"] = resumeJson;

            return RedirectToAction("CreateResumeOverload", "Resume", new { id });
        }
        [HttpPost]
        public IActionResult RemoveField(int caseId, int profId, Resume resume)
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
            string resumeJson = JsonSerializer.Serialize(resume);
            TempData["ResumeData"] = resumeJson;

            return RedirectToAction("CreateResumeOverload", "Resume", new { profId });
        }
    }
}
