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

		public IActionResult showProject()
		{
			var projects = from project in context.Projects
						   select project;

			return View(projects.ToList());
		}


        public IActionResult Add()
        {

            return View(new Project());

        }

        [HttpPost]
		public async Task<IActionResult> Add(Project project)
		{
			if (ModelState.IsValid)
			{


				//OBS denna kan vara fel , först loopa genom alla profiler i context genom en linq och sen vill jag jämföra deras userID nyckel med den userid som currentuser har
				//hämta användare
				var currentUser = await _userManager.GetUserAsync(User);

				var userProfile = context.Profiles.FirstOrDefault(p => p.Id.ToString() == currentUser.Id);

				if (userProfile != null)

				{
					project.ProjectOwnerId = userProfile.Id;

					context.Projects.Add(project);

					var ownerParticipation = new ParticipatesIn
					{
						ProfileId = userProfile.Id,
						ProjectId = project.Id
					};

					context.Participants.Add(ownerParticipation);

					await context.SaveChangesAsync();

					return RedirectToAction("ShowProject");
				}

				else
				{
					ModelState.AddModelError("", "Ingen profil hittades för användaren.");
				}


			}

			return View("Add", project);

		}




		[HttpPost]
		public async Task<IActionResult> Edit(Project project)
		{
			if (ModelState.IsValid)
			{
				var existingProject = context.Projects.FirstOrDefault(p => p.Title == project.Title);

				if (existingProject != null)
				{
					existingProject.Title = project.Title;
					existingProject.Description = project.Description;
					existingProject.Updated = DateTime.Now;

					context.Update(existingProject);
					await context.SaveChangesAsync();

					return RedirectToAction("ShowProject");
				}

				else
				{
					return View(project);
				}
			}

			return View(project);
		}






	}
}