using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers



{
    [Authorize] // Lägg till [Authorize] för att kräva inloggning för hela kontrollern
    public class ProjectController : Controller
	{


		public CVContext context {  get; set; }
		public ProjectController(CVContext _context) 
		
		{
			context = _context;
		}

        [AllowAnonymous] // Tillåt åtkomst utan inloggning för ShowProject
        public IActionResult showProject()
		{
            var projects = context.Projects.Include(p => p.ProjectOwner).ToList();
            return View(projects);
        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            if (ModelState.IsValid)
            {
                context.Projects.Add(project);
                context.SaveChanges();

                return RedirectToAction("ShowProject");
            }

            // Om modellen inte är giltig, återvänder till samma vy för kunna visa felmeddelanden
            return View("Add", project);
        }
    

        public IActionResult EditProject(int id)
        {
            var project = context.Projects.Find(id);
            return View(project);
        }


        [HttpPost]
        public IActionResult EditProject(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("ShowProject");
        }



    }
}
