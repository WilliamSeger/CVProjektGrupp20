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
            //gets the currently signed in user
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            //gets the currently signed in profile
            var profileQuery = from profile in _context.Profiles
                               where profile.UserId == user.Id
                               select profile;
            Profile userProfile = new Profile();
            userProfile = profileQuery.FirstOrDefault();

            //controlls that there is a profile
            if (userProfile == null)
            {
                return RedirectToAction("CreateProfile", "Profile");
            }
            //gets the recieved messages for the profile
            var messageQuery = from message in _context.Messages
                               where message.RecieverId == userProfile.Id
                               select message;

            var anonMessageQuery = from anonMessage in _context.anonMessages
                                   where anonMessage.RecieverId == userProfile.Id
                                   select anonMessage;
            //puts the anonymous messages in a viewbag to send into the view
            List<AnonymousMessage> anonymousMessages = anonMessageQuery.ToList();
            ViewBag.AnonMessages = anonymousMessages;
            //puts the regular messages in a list to send into the view as model
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
            Profile userProfile = senderQuery.ToList().FirstOrDefault();

            
            if (userProfile == null)
            {
                return RedirectToAction("CreateProfile", "Profile");
            }
            //gets the profile for the selected reciever
            var recieverQuery = from profile in _context.Profiles
                                where profile.Id == id
                                select profile;

            Profile recieverProfile = recieverQuery.ToList().FirstOrDefault();

            //sends the user and the recievers profiles to the view
            ViewBag.Sender = userProfile;
            ViewBag.Reciever = recieverProfile;
            //assigns values to the sendmessage view model
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
            //gets the reciever and sender profiles
            var senderQuery = from profile in _context.Profiles
                              where profile.Id == senderId
                              select profile;
            var recieverQuery = from profile in _context.Profiles
                                where profile.Id == recieverId
                                select profile;

            Profile senderProfile = senderQuery.ToList().First();
            Profile recieverProfile = recieverQuery.ToList().First();
            //creates a message object and assigns the values from the sendmessageviewmodel to the message object
            Message message = new Message();
            message.Created = DateTime.Now;
            message.Content = viewModel.Content;
            message.IsRead = viewModel.IsRead;
            message.Sender = senderProfile;
            message.SenderId = senderProfile.Id;
            message.Reciever = recieverProfile;
            message.RecieverId = recieverProfile.Id;

            User recieverUser = recieverProfile.User;
            //increments the MessageCount value for the recieving user
            if (recieverUser.MessagesCount == null || recieverUser.MessagesCount == 0)
            {
                recieverUser.MessagesCount = 1;
            }
            else
            {
                recieverUser.MessagesCount = (recieverUser.MessagesCount + 1);
            }

            if (message.Sender != null && message.Reciever != null)
            {
                //saves the message to the database and shows an alertmessage
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
            //increments the MessageCount value for the recieving user
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
                //saves the message to the database and shows an alertmessage
                _context.anonMessages.Add(message);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Message sent succesfully";

                return RedirectToAction("Search", "Resume");
            }

            return View("Views/Message/SendAnonymousMessage.cshtml", viewModel);

        }

        public async Task<IActionResult> MessageIsRead(int msgId)
        {
            //gets the message object that was read
            var messageQuery = from message in _context.Messages
                               where message.Id == msgId
                               select message;
            Message currentMessage = new Message();
            if (messageQuery != null)
            {
                //changes the state of the object and saves
                currentMessage = messageQuery.FirstOrDefault();
                currentMessage.IsRead = true;
                _context.Messages.Update(currentMessage);
                _context.SaveChanges();
            }

            //gets the user object for the user that read the message and reduces the Messagecount value by 1
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            user.MessagesCount = user.MessagesCount - 1;
            _context.SaveChanges();
            
            var profileQuery = from profile in _context.Profiles
                               where profile.UserId == user.Id
                               select profile;
            Profile userProfile = profileQuery.FirstOrDefault();
            //gets all the messages for the user to send it back to the recieved messages view again
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
            //gets the message object that was read
            var messageQuery = from message in _context.anonMessages
                               where message.Id == msgId
                               select message;
            AnonymousMessage currentMessage = new AnonymousMessage();
            if (messageQuery != null)
            {
                //changes the state of the object and saves
                currentMessage = messageQuery.FirstOrDefault();
                currentMessage.IsRead = true;
                _context.anonMessages.Update(currentMessage);
                _context.SaveChanges();
            }
            //gets the user object for the user that read the message and reduces the Messagecount value by 1
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            user.MessagesCount = user.MessagesCount - 1;
            _context.SaveChanges();

            var profileQuery = from profile in _context.Profiles
                               where profile.UserId == user.Id
                               select profile;
            Profile userProfile = profileQuery.FirstOrDefault();
            //gets all the messages for the user to send it back to the recieved messages view again
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