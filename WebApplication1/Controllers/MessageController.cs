﻿using Microsoft.AspNetCore.Authorization;
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
			
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var profileQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			Profile userProfile = profileQuery.FirstOrDefault();

			var messageQuery = from message in _context.Messages
							   where message.RecieverId == userProfile.Id
							   select message; 
			
			List<Message> messages = messageQuery.ToList();

			return View(messages);
		}

		[Authorize]
		public async Task<IActionResult> SendMessage(int id)
		{
			User user = await userManager.FindByNameAsync(User.Identity.Name);
			var senderQuery = from profile in _context.Profiles
							   where profile.UserId == user.Id
							   select profile;
			var recieverQuery = from profile in _context.Profiles
								where profile.Id == id
								select profile;

			Profile userProfile = senderQuery.ToList().First();
			Profile recieverProfile = recieverQuery.ToList().First();

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
			if (message.Sender != null && message.Reciever != null)
			{
				_context.Messages.Add(message);
				_context.SaveChanges();
				TempData["AlertMessage"] = "Message sent succesfully";

				return RedirectToAction("Search", "Resume");
			}

			return View("Views/Message/SendMessage.cshtml", viewModel);

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