using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
	public class ProjectController : Controller
	{

		public CVContext _context;
		public ProjectController(CVContext context) 
		
		{
			_context = context;
		}

		public IActionResult showProject()
		{

			return View();
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
