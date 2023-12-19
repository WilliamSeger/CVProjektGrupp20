using Microsoft.AspNetCore.Mvc;
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

    }
}
