﻿namespace WebApplication1.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Boolean IsPrivate { get; set; }
        public virtual ICollection<ParticipatesIn> Projects { get; set; } = new List<ParticipatesIn>();

        //insert Picture
        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public virtual User User { get; set; }
    }
}
