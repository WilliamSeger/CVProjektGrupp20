using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
	public class ProjectController : Controller
	{

		public CVContext _service {  get; set; }
		public ProjectController(CVContext service) 
		
		{
			_service = service;
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
