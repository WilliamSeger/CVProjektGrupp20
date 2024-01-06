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
			var participants = from participant in context.Participants
							   select participant;
			ViewBag.AllParticipants = participants.ToList();

			if (User.Identity.IsAuthenticated)
			{
				User user = await _userManager.FindByNameAsync(User.Identity.Name);
				var profile = from profileObj in context.Profiles
							  where profileObj.UserId == user.Id
							  select profileObj;
				Profile userProfile = profile.FirstOrDefault();
				ViewBag.Profile = userProfile;

				var myParticipations = from participant in context.Participants
								   where participant.ProfileId == userProfile.Id
								   select participant.ProjectId;
				ViewBag.UserParticipationId = myParticipations.ToList();
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
		public IActionResult Delete(int id) 
		{
			var projectList = from project in context.Projects
							  where project.Id == id
							  select project;
			Project projectToDelete = projectList.FirstOrDefault();
            var participantList = from participants in context.Participants
                              where participants.ProjectId == id
                              select participants;

            if (participantList != null)
            {
                List<ParticipatesIn> participantsToDelete = participantList.ToList();
                foreach (var participant in participantsToDelete)
				{
                    context.Participants.Remove(participant);
                }
                context.SaveChanges();
            }

            if (projectToDelete != null)
			{
				context.Projects.Remove(projectToDelete);
				context.SaveChanges();
			}

			return RedirectToAction("showProject");
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
				TempData["AlertMessage"] = "Project updated succesfully";
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

			Profile userprofile = profile.FirstOrDefault();
			if (userprofile != null)
			{
				var participation = new ParticipatesIn
				{
					ProfileId = userprofile.Id,
					ProjectId = projectId
				};

				context.Participants.Add(participation);
				await context.SaveChangesAsync();
			}

			return RedirectToAction("showProject");

		}

        [HttpPost]
        public async Task<IActionResult> Leave(int projectId)
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var profile = from profileObj in context.Profiles
                          where profileObj.UserId == user.Id
                          select profileObj;

            Profile userprofile = profile.FirstOrDefault();
            if (userprofile != null)
            {
                var participant = from participantObj in context.Participants
								  where participantObj.ProfileId == userprofile.Id
								  where participantObj.ProjectId == projectId
								  select participantObj;
                ParticipatesIn currentParticipant = participant.FirstOrDefault();

                context.Participants.Remove(currentParticipant);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("showProject");

        }
    }
}