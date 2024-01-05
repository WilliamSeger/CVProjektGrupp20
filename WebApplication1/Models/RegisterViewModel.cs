using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class RegisterViewModel : LayoutViewModel
	{
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Username has to be between 2 and 50 characters")]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Password has to be between 3 and 20 characters")]
		[Compare("ConfirmPassword")]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
	}
}
