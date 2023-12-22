using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class Message
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime Created { get; set; }
		public int SenderId { get; set; }
		public int RecieverId { get; set; }
		[ForeignKey(nameof(SenderId))]
		public virtual Profile SenderProfile { get; set; }
		[ForeignKey(nameof(RecieverId))]
		public virtual Profile RecieverProfile { get; set; }

	}
}
