using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class ResumeController : Controller
    {
        private CVContext _context;
        public ResumeController(CVContext context) 
        { 
            _context = context;
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
		
		public IActionResult EditResume(int id)
		{
			//Fetches the resume that corresponds to the profile 
			var resumeList = from resume in _context.Resumes
							  where resume.ProfileId == id
							  select resume;

			return View(resumeList.ToList().FirstOrDefault());
		}
		[HttpPost]
		public IActionResult Edit(Resume resume)
		{
			//Edits an exitsting resume with values provided by userinputs. Updates database
			_context.Update(resume);
			_context.SaveChanges();

			var resumeList = from oldResume in _context.Resumes
							  where oldResume.Id == resume.Id
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
		public IActionResult CreateResume(int id)
		{
			//Creates a new blank resume and sends it to the view. The lists contains dummy items because the input fields in the view needs items in the list to attach to.
			var newResume = new Resume
			{
				ProfileId = id,
				Qualification = new List<string> { "Item 1"},
				Phonenumber = new List<string> { "Item 1"},
				Education = new List<string> { "Item 1"},
				Experiences = new List<string> { "Item 1"}
			};

            return View(newResume);
		}
	}
}
