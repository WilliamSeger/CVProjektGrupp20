using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Användarnamnet måste innehålla minst 2 och max 50 tecken.")]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Lösenordet måste innehålla minst 3 och max 20 tecken.")]
		[Compare("ConfirmPassword")]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Bekräfta lösenord")]
		public string ConfirmPassword { get; set; }
	}
}
