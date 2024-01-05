using Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string ProfilePicturePath { get; set; }
        [Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Name has to be between 2 and 50 characters")]
		public string Name { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Adress has to be between 2 and 50 characters")]
		public string Adress { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9]{1,}@[a-zA-Z]{2,}\.[a-zA-Z]{2,}$", ErrorMessage = "You need to input a valid Email")]
		public List<string> Email { get; set; }
        public Boolean IsPrivate { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
		public virtual IEnumerable<Message> SentMessages { get; set; } = new List<Message>();
		public virtual IEnumerable<Message> RecievedMessages { get; set; } = new List<Message>();

		public virtual IEnumerable<AnonymousMessage> RecievedAnonymousMessages { get; set; } = new List<AnonymousMessage>();
		public virtual ICollection<ParticipatesIn> ParticipatesIn { get; set; } = new List<ParticipatesIn>();
    }
}
