using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;
public class Resume
{
    public int Id { get; set; }
    public string Email { get; set; }
    [Required]
    public List<string> Qualification { get; set; }
    [Required]
    public List<string> Phonenumber { get; set; }
    [Required]
    public List<string> Education { get; set; }
}
