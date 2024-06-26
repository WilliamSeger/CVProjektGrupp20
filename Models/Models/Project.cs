﻿using Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Project
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

		public virtual ICollection<ParticipatesIn> ParticipatesIn { get; set; } = new List<ParticipatesIn>();
		public int ProjectOwnerId { get; set; }
		[ForeignKey(nameof(ProjectOwnerId))]
		public virtual Profile ProjectOwner { get; set; } // Främmande nyckel för ägaren av projektet
	}

}

