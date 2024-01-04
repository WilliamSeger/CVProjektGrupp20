using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
	public class ProjectController : BaseController
	{

		public CVContext context {  get; set; }
		public ProjectController(CVContext _context, UserManager<User> userManager) : base(_context, userManager)
		
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
