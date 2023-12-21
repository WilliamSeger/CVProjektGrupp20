using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class ChangePasswordViewModel
	{
		[Required]
		public string CurrentPassword { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Lösenordet måste innehålla minst 3 och max 20 tecken.")]
		[Compare("ConfirmPassword", ErrorMessage = "Lösenordsfälten stämmer inte överens")]
		public string NewPassword { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
