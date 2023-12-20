using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Models
{
    public class CVContext : IdentityDbContext<User>
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options) { }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Resume>().HasData(
                new Resume
                {
                    Id = 1,
                    Email = "Alexstuvsta@bingus.se",
                    Qualification = new List<string> { "bingus", "bongus" },
                    Phonenumber = new List<string> { "09348", "094854" },
                    Education = new List<string> { "Harvard", "Yale" }

                },
                new Resume
                {
                    Id = 2,
                    Email = "Alexstuvsta@bingus.se",
                    Qualification = new List<string> { "bin", "bon" },
                    Phonenumber = new List<string> { "09348999", "99094854" },
                    Education = new List<string> { "Harvardle", "Yalebon" }

                },
                new Resume
                {
                    Id = 3,
                    Email = "Alexstuvsta@bingus.se",
                    Qualification = new List<string> { "binguruskus", "sibongus" },
                    Phonenumber = new List<string> { "66609348", "666094854" },
                    Education = new List<string> { "FakeHarvard", "RealYale" }

                }
                );
            //modelBuilder.Entity<Project>().HasData(
            //    new Project
            //    {
            //        Id = 1,
            //        Title = "MIB",
            //        Description = "JAVA project",
            //        Created = DateTime.Now,
            //        Updated = DateTime.Now
            //    }
            //    ,
            //    new Project
            //    {
            //        Id = 2,
            //        Title = "Hattmakaren",
            //        Description = "SCRUM Project",
            //        Created = DateTime.Now,
            //        Updated = DateTime.Now
            //    }
            //);
        }
    }
}
