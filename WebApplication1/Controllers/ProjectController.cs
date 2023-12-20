using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
	public class ProjectController : Controller
	{

		public CVContext context {  get; set; }
		public ProjectController(CVContext _context) 
		
		{
			context = _context;
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
