namespace WebApplication1.Models
{
    public class Project
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int ProjectOwnerId { get; set; }
        public virtual List<User> Participants { get; set; }


        public Project(string title, string description, DateTime created, DateTime updated)
        {
            Title = title;
            Description = description;
            Created = created;
            Updated = updated;
        }


    }

}

