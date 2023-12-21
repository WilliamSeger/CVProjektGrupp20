namespace WebApplication1.Models
{
    public class ParticipatesIn
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
