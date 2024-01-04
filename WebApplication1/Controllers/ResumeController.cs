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
            var resumeList = from resume in _context.Resumes
                             select resume;
            
            return View(resumeList.ToList());
        }
		//Alex lagt till
		public IActionResult EditResume(int id)
		{
			var resumeList = from resume in _context.Resumes
							  where resume.Id == id
							  select resume;

			return View(resumeList.ToList().FirstOrDefault());
		}
		[HttpPost]
		public IActionResult Edit(Resume resume)
		{
			
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
			// Find all resumes with the specified ProfileId
			var resumesToDelete = _context.Resumes.Where(r => r.ProfileId == id);

			// Remove each resume from the context
			foreach (var resume in resumesToDelete)
			{
				_context.Resumes.Remove(resume);
			}

			// Save changes to the database
			_context.SaveChanges();

			// Redirect to the desired action (e.g., ProfileView)
			return RedirectToAction("ProfileView", "Profile", new { id });
		}
		[Authorize]
		[HttpPost]
		public IActionResult AddNew(Resume resume)
		{
			// Create a new instance of the Resume model
	

			// Add the new Resume to the context
			_context.Resumes.Add(resume);

			// Save changes to the database
			_context.SaveChanges();

			// Redirect to the EditResume action with the newly created Resume's Id
			return RedirectToAction("ProfileView", "Profile", new { id = resume.ProfileId });
			
		}
		[Authorize]
		public IActionResult CreateResume(int id)
		{
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
		//slut på de ja la till
	}
}
