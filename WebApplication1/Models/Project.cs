namespace WebApplication1.Models
{
    public class Project : LayoutViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int ProjectOwnerId { get; set; }
        public virtual List<Profile> Participants { get; set; }


        
        


    }

}

