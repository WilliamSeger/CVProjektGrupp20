using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options) 
        {

        }
    }
}
