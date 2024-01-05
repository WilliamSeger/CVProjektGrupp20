﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Profile : LayoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<string> Email { get; set; }
        public Boolean IsPrivate { get; set; }
        //public byte[] Picture { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
		public virtual IEnumerable<Message> SentMessages { get; set; } = new List<Message>();
		public virtual IEnumerable<Message> RecievedMessages { get; set; } = new List<Message>();
	}
}