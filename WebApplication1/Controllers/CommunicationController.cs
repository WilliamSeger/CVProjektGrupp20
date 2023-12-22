using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class CommunicationController : Controller
	{
		public CVContext _context;

		public CommunicationController(CVContext context) 
		{
			_context = context;
		}

		public IActionResult Conversations()
		{
			string userName = User.Identity.Name;
			var currentUser = from user in _context.Users
							  where user.UserName == userName
							  select user;
			User currUser = currentUser.ToList().FirstOrDefault();

			var currentProfile = from profile in _context.Profiles
								 where profile.UserId == currUser.Id
								 select profile;
			int currProfileId = currentProfile.ToList().FirstOrDefault().Id;

			var conversationList = from message in _context.Messages
								   where message.SenderId == currProfileId || message.RecieverId == currProfileId
								   orderby message.Created descending
								   select message;

			if (conversationList != null)
			{
                return View(conversationList.ToList());
            }
			else
			{
				return RedirectToAction("ViewProfile", "Profile", currProfileId);
			}
			
		}
	}
}
