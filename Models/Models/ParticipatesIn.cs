using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Models.Models
{
	public class ParticipatesIn
	{
		public int ProjectId { get; set; }
		public int ProfileId { get; set; }

		[ForeignKey(nameof(ProjectId))]
		public virtual Project Project { get; set; }

		[ForeignKey(nameof(ProfileId))]
		public virtual Profile Profile { get; set; }

		//public int ProjectId { get; set; }
		//public virtual Project Project { get; set; }

		//public int ProfileId { get; set; }
		//public virtual Profile Profile { get; set; }
	}
}
