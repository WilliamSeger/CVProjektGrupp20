using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
	public class ProjectController : Controller
	{

		public CVContext _context {  get; set; }
		public ProjectController(CVContext context) 
		
		{
			_context = context;
		}

		public IActionResult showProject()
		{
            var projectList = from project in _context.Projects
							  orderby project.Created descending
                              select project;
            return View(projectList.ToList());
        }

		public IActionResult AddProject()
		{
			return View();
		}

		public IActionResult EditProject()
		{
			return View();
		}
	}
}
