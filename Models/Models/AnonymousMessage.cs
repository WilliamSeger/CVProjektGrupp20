using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Models.Models
{
    public class AnonymousMessage
    {
        public int Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsRead { get; set; }
        [Required]
        public string SenderName { get; set; }
        public int RecieverId { get; set; }
        [ForeignKey(nameof(RecieverId))]
        public virtual Profile Reciever { get; set; }
    }
}