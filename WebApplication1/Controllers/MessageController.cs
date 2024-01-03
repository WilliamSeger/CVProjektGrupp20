using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class MessageController : Controller
	{
		CVContext _context;
		private UserManager<User> userManager;

		public MessageController(CVContext context, UserManager<User> userManager)
		{
			_context = context;
			this.userManager = userManager;
		}

		public async Task<IActionResult> Recieved()
		{
			/*
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			Profile userProfile = profileQuery.FirstOrDefault();

			var messageQuery = from message in _context.Messages
							   where message.RecieverId == userProfile.Id
							   select message; 
			*/
			var messageQuery = from message in _context.Messages
							   select message;
			List<Message> messages = messageQuery.ToList();

			return View(messages);
		}

		public IActionResult MessageIsRead(int msgId)
		{
			var messageQuery = from message in _context.Messages
							   where message.Id == msgId
							   select message;
			Message currentMessage = new Message();
			if(messageQuery != null)
			{
				currentMessage = messageQuery.FirstOrDefault();
				currentMessage.IsRead = true;
				_context.Messages.Update(currentMessage);
				_context.SaveChanges();
			}

			var newMessageQuery = from message in _context.Messages
							   select message;
			List<Message> messages = newMessageQuery.ToList();

			return View("Recieved", messages);
		}
	}
}
