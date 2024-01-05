using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using WebApplication1.Models;
using Models.Models;

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
			
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			Profile userProfile = new Profile();
			userProfile = profileQuery.FirstOrDefault();

			//Profilkontroll
			if (userProfile == null)
			{
				return RedirectToAction("CreateProfile","Profile");
			}

			var messageQuery = from message in _context.Messages
							   where message.RecieverId == userProfile.Id
							   select message; 

			var anonMessageQuery = from anonMessage in _context.anonMessages
								   where anonMessage.RecieverId == userProfile.Id
								   select anonMessage;
			List<AnonymousMessage> anonymousMessages = anonMessageQuery.ToList();
			if (anonymousMessages.IsNullOrEmpty())
			{
				ViewBag.AnonMessages = new List<AnonymousMessage>();
			}
			else
			{
				ViewBag.AnonMessages = anonymousMessages;
			}

			List < Message > messages = messageQuery.ToList();

			return View(messages);
		}

		[Authorize]
		public async Task<IActionResult> SendMessage(int id)
		{
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var senderQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			Profile userProfile = senderQuery.ToList().FirstOrDefault();

			//Profilkontroll
			if (userProfile == null)
			{
				return RedirectToAction("CreateProfile", "Profile");
			}

			var recieverQuery = from profile in _context.Profiles
								where profile.Id == id
								select profile;

			Profile recieverProfile = recieverQuery.ToList().FirstOrDefault();
			User recieverUser = recieverProfile.User;
			

			//Skickar med avsändaren samt mottagaren
			ViewBag.Sender = userProfile;
			ViewBag.Reciever = recieverProfile;

			SendMessageViewModel sendMessageViewModel = new SendMessageViewModel
			{
				IsRead = false,
				SenderId = userProfile.Id,
				Sender = userProfile,
				RecieverId = recieverProfile.Id,
				Reciever = recieverProfile
			};
			return View(sendMessageViewModel);
		}

		public async Task<IActionResult> SendAnonymousMessage(int id)
		{			
			var recieverQuery = from profile in _context.Profiles
								where profile.Id == id
								select profile;

			Profile recieverProfile = recieverQuery.ToList().FirstOrDefault();
			
			//Skickar med mottagaren
			ViewBag.Reciever = recieverProfile;

			SendAnonymousMessageViewModel sendMessageViewModel = new SendAnonymousMessageViewModel
			{
				IsRead = false,
				RecieverId = recieverProfile.Id,
				Reciever = recieverProfile
			};
			return View(sendMessageViewModel);
		}

		[HttpPost]
		public IActionResult CreateMessage(SendMessageViewModel viewModel, int senderId, int recieverId)
		{
			var senderQuery = from profile in _context.Profiles
							  where profile.Id == senderId
							  select profile;
			var recieverQuery = from profile in _context.Profiles
								where profile.Id == recieverId
								select profile;

			Profile senderProfile = senderQuery.ToList().First();
			Profile recieverProfile = recieverQuery.ToList().First();

			Message message = new Message();
			message.Created = DateTime.Now;
			message.Content = viewModel.Content;
			message.IsRead = viewModel.IsRead;
			message.Sender = senderProfile;
			message.SenderId = senderProfile.Id;
			message.Reciever = recieverProfile;
			message.RecieverId = recieverProfile.Id;
			User recieverUser = recieverProfile.User;

			if (recieverUser.MessagesCount == null || recieverUser.MessagesCount == 0)
			{
				recieverUser.MessagesCount = 1;
			}
			else
			{
				recieverUser.MessagesCount = (recieverUser.MessagesCount + 1);
			}

			if (message.Sender != null && message.Reciever != null && message.Content != null)
			{
				_context.Messages.Add(message);
				_context.SaveChanges();
				TempData["AlertMessage"] = "Message sent succesfully";

				return RedirectToAction("Search", "Resume");
			}

			return View("Views/Message/SendMessage.cshtml", viewModel);

		}

		[HttpPost]
		public IActionResult CreateAnonymousMessage(SendAnonymousMessageViewModel viewModel, int recieverId)
		{
			var recieverQuery = from profile in _context.Profiles
								where profile.Id == recieverId
								select profile;

			Profile recieverProfile = recieverQuery.ToList().First();

			AnonymousMessage message = new AnonymousMessage();
			message.Created = DateTime.Now;
			message.Content = viewModel.Content;
			message.IsRead = viewModel.IsRead;
			message.Reciever = recieverProfile;
			message.RecieverId = recieverProfile.Id;
			message.SenderName = viewModel.SenderName;

			User recieverUser = recieverProfile.User;

			if (recieverUser.MessagesCount == null || recieverUser.MessagesCount == 0)
			{
				recieverUser.MessagesCount = 1;
			}
			else
			{
				recieverUser.MessagesCount = (recieverUser.MessagesCount + 1);
			}


			if (message.Reciever != null)
			{
				_context.anonMessages.Add(message);
				_context.SaveChanges();
				TempData["AlertMessage"] = "Message sent succesfully";

				return RedirectToAction("Search", "Resume");
			}

			return View("Views/Message/SendAnonymousMessage.cshtml", viewModel);

		}

		public async Task<IActionResult> MessageIsRead(int msgId)
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

		User user = await userManager.FindByNameAsync(User.Identity.Name);

			user.MessagesCount = user.MessagesCount - 1;
			_context.SaveChanges();
		var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
		Profile userProfile = profileQuery.FirstOrDefault();

		var recievedMessageQuery = from message in _context.Messages
							   where message.RecieverId == userProfile.Id
							   select message;
			var anonMessageQuery = from anonMessage in _context.anonMessages
								   where anonMessage.RecieverId == userProfile.Id
								   select anonMessage;
			ViewBag.AnonMessages = anonMessageQuery.ToList();
			List<Message> messages = recievedMessageQuery.ToList();

		return View("Recieved", messages);
		}

		public async Task<IActionResult> AnonMessageIsRead(int msgId)
		{
			var messageQuery = from message in _context.anonMessages
							   where message.Id == msgId
							   select message;
			AnonymousMessage currentMessage = new AnonymousMessage();
			if (messageQuery != null)
			{
				currentMessage = messageQuery.FirstOrDefault();
				currentMessage.IsRead = true;
				_context.anonMessages.Update(currentMessage);
				_context.SaveChanges();
			}

			User user = await userManager.FindByNameAsync(User.Identity.Name);
			user.MessagesCount = user.MessagesCount - 1;
			_context.SaveChanges();
			var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			Profile userProfile = profileQuery.FirstOrDefault();

			var recievedMessageQuery = from message in _context.Messages
									   where message.RecieverId == userProfile.Id
									   select message;

			var anonMessageQuery = from anonMessage in _context.anonMessages
								   where anonMessage.RecieverId == userProfile.Id
								   select anonMessage;
			ViewBag.AnonMessages = anonMessageQuery.ToList();

			List<Message> messages = recievedMessageQuery.ToList();

			return View("Recieved", messages);
		}
	}
}
