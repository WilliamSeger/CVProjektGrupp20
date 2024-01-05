using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
	public class CreateProfileViewModel
	{
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Name has to be between 2 and 50 characters")]
		public string Name { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Adress has to be between 2 and 50 characters")]
		public string Adress { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z]{1,}@[a-zA-Z]{2,}\.[a-zA-Z]{2,}$", ErrorMessage = "You need to input a valid Email")]
		public string Email { get; set; }
		[Required]
		public Boolean IsPrivate { get; set; }
	}
}
