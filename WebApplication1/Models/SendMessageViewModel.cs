using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class SendMessageViewModel
	{
		public int Id { get; set; }
		[Required]
		public DateTime Created { get; set; }
		[Required]
		public string Content { get; set; }
		[Required]
		public bool IsRead { get; set; }
		public int SenderId { get; set; }
		[ForeignKey(nameof(SenderId))]
		public virtual Profile Sender { get; set; }
		public int RecieverId { get; set; }
		[ForeignKey(nameof(RecieverId))]
		public virtual Profile Reciever { get; set; }
	}
}
