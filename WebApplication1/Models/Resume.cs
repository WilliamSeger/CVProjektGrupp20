namespace WebApplication1.Models
{
    
    public class Resume
    {
        public Resume() { }
        int Id { get; set; }
        string Email { get; set; }
        List<string> Qualification { get; set; }
        List<string> Phonenumber { get; set; }
        List<string> Education { get; set; }
    }
}
