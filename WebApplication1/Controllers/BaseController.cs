﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class BaseController : Controller
	{
		
		public UserManager<User> userManager;
		public CVContext _context;

		public BaseController(CVContext _context, UserManager<User> userManager)
		{
			this._context = _context;
			this.userManager = userManager;
			messageCount();
		}
		//public override async void OnActionExecuted(ActionExecutedContext context)
		//{
		//	if (User.Identity.IsAuthenticated)
		//	{
		//		User currentUser = await userManager.FindByNameAsync(User.Identity.Name);
		//		var profileList = from profile in _context.Profiles
		//						  where profile.UserId == currentUser.Id
		//						  select profile;
		//		Profile currentProfile = profileList.FirstOrDefault();
		//		var messagesIn = from message in _context.Messages
		//						 where message.RecieverId == currentProfile.Id
		//						 where message.IsRead == false
		//						 select message;

		//		ViewBag.MessagesCount = messagesIn.Count();
		//	}
		//	base.OnActionExecuted(context);
		//}

		public async void messageCount()
		{
			
			string? userName = User.Identity.Name;
			if (userName == null)
			{

			}
			else
			{

				User currentUser = await userManager.FindByNameAsync(userName);

				var profileList = from profile in _context.Profiles
								  where profile.UserId == currentUser.Id
								  select profile;
				Profile currentProfile = profileList.FirstOrDefault();
				var messagesIn = from message in _context.Messages
								 where message.RecieverId == currentProfile.Id
								 where message.IsRead == false
								 select message;

				ViewBag.MessagesCount = messagesIn.Count();
			}
			
		}
	}
}
