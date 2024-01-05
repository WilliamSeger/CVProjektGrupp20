using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class User : IdentityUser
	{
		public int MessagesCount { get; set; }
	}
}
