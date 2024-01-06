using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers



{
	[Authorize] // Lägg till [Authorize] för att kräva inloggning för hela kontrollern
	public class ProjectController : Controller
	{

		private UserManager<User> _userManager { get; set; }
		public CVContext context { get; set; }
		public ProjectController(UserManager<User> userManager, CVContext _context)

		{
			context = _context;
			_userManager = userManager;
		}

		[AllowAnonymous] // Tillåt åtkomst utan inloggning för ShowProject

		public async Task<IActionResult> showProject()
		{
			var projects = from project in context.Projects
						   select project;
			if (User.Identity.IsAuthenticated)
			{
				User user = await _userManager.FindByNameAsync(User.Identity.Name);
				var profile = from profileObj in context.Profiles
							  where profileObj.UserId == user.Id
							  select profileObj;
				ViewBag.Profile = profile.FirstOrDefault();
			}
			return View(projects.ToList());
		}


		public IActionResult Create()
		{
			CreateProjectViewModel viewModel = new CreateProjectViewModel();


            return View("add", viewModel);

		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateProjectViewModel viewmodel)
		{
			if (ModelState.IsValid)
			{
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                var profileQuery = from profileObj in context.Profiles
                              where profileObj.UserId == user.Id
                              select profileObj;
				Profile profile = profileQuery.FirstOrDefault();

				Project project = new Project();
				project.Title = viewmodel.Title;
				project.Description = viewmodel.Description;
				project.Created = DateTime.Now;
				project.Updated =	DateTime.Now;

				project.ParticipatesIn = new List<ParticipatesIn>();
				project.ProjectOwner = profile;
				project.ProjectOwnerId = profile.Id;

				context.Add(project);
				context.SaveChanges();

				TempData["AlertMessage"] = "Project Created sucessfully";
				return RedirectToAction("showProject");




			}

			return View("Add", viewmodel);

		}




		[HttpPost]
		public IActionResult Edit(Project project, int Id)
		{
			var existingProject = context.Projects.Where(project => project.Id == Id);
			Project currentProject = existingProject.FirstOrDefault();

			if (project.Title != null)
			{
				currentProject.Title = project.Title;

			}

			if (project.Description != null)
			{
				currentProject.Description = project.Description;
			}

			if (project != null)
			{
				currentProject.Updated = DateTime.Now;
				context.Update(currentProject);
				context.SaveChanges();
				TempData["AlertMessage"] = "Resume updated succesfully";
				return RedirectToAction("showProject");
			}

			return View("Edit", project);

		}







		[HttpGet]
		public IActionResult EditProject(int id)
		{
			Project project = context.Projects.Find(id);



			return View("Edit", project);

		}


		[HttpPost]

		public async Task<IActionResult> Participate(int projectId)
		{
			User user = await _userManager.FindByNameAsync(User.Identity.Name);
			var profile = from profileObj in context.Profiles
						  where profileObj.UserId == user.Id
						  select profileObj;

			Profile newprofile = profile.FirstOrDefault();
			if (newprofile != null)
			{
				var participation = new ParticipatesIn
				{
					ProfileId = newprofile.Id,
					ProjectId = projectId
				};

				context.Participants.Add(participation);
				await context.SaveChangesAsync();
			}

			return RedirectToAction("showProject");

		}
	}
}