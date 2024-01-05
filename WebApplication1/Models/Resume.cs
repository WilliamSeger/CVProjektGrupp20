using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
namespace WebApplication1.Models;
public class Resume : LayoutViewModel
{
	//Test för att se om jag kan fixa en grej med create
	public Resume()
	{
		
		Qualification = new List<string>();
		Phonenumber = new List<string>();
		Education = new List<string>();
		Experiences = new List<string>();
	}
	public int Id { get; set; }
    [Required]
    public List<string> Qualification { get; set; }
    [Required]
    public List<string> Phonenumber { get; set; }
    [Required]
    public List<string> Education { get; set; }
    public List<string> Experiences { get; set; }
	
	[Required]
    public int ProfileId {  get; set; }
    [ForeignKey(nameof(ProfileId))]
    public virtual Profile Profile { get; set; }
}
