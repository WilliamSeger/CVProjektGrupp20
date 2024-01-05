using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class ChangeUserNameViewModel : LayoutViewModel
	{
	
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Användarnamnet måste innehålla minst 2 och max 50 tecken.")]
		public string NewUserName { get; set; }
	}
}