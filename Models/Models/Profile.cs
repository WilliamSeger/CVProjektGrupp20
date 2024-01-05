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
        public string Name { get; set; }
        public string Adress { get; set; }
        [Required]
        public List<string> Email { get; set; }
        public Boolean IsPrivate { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
		public virtual IEnumerable<Message> SentMessages { get; set; } = new List<Message>();
		public virtual IEnumerable<Message> RecievedMessages { get; set; } = new List<Message>();
		public virtual ICollection<ParticipatesIn> ParticipatesIn { get; set; } = new List<ParticipatesIn>();
        public virtual IEnumerable<AnonymousMessage> RecievedAnonymousMessages { get; set; } = new List<AnonymousMessage>();

    }
}
