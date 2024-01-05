using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using WebApplication1.Models;


namespace WebApplication1.Models
{
    public class CVContext : IdentityDbContext<User>
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options) { }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
		public DbSet<Message> Messages { get; set; }
        public DbSet<AnonymousMessage> anonMessages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {   
                    Id = "123",
                    UserName = "Admin",
                    PasswordHash = "1234Abc!"
                }
                );
			modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = 1,
                    Name = "Bong",
                    ProfilePicturePath = "",
                    Adress = "väggatan",
                    Email = new List<string> { "hej@gmail.com", "hej@jobb.com" },
                    IsPrivate = false,
                    UserId = "123"
                },
                new Profile
                {
                    Id = 2,
                    Name = "Bongus",
                    ProfilePicturePath = "",
                    Adress = "väggatan 4",
                    Email = new List<string> { "hallå@hotmail.com", "hallå@företag.se" },
                    IsPrivate = false,
                    UserId = "123"
                },
                new Profile
                {
                    Id = 3,
                    Name = "Bing",
                    ProfilePicturePath = "",
                    Adress = "väggatan 2",
                    Email = new List<string> { "meh@yahoo.com", "meh@arbete.com" },
                    IsPrivate = false,
                    UserId = "123"
                }
                );
            modelBuilder.Entity<Resume>().HasData(
                new Resume
                {
                    Id = 1,
                    Qualification = new List<string> { "bingus", "bongus" },
                    Phonenumber = new List<string> { "09348", "094854" },
                    Education = new List<string> { "Harvard", "Yale" },
                    Experiences = new List<string> { "Amgus champion"},
                    ProfileId = 1

                },
                new Resume
                {
                    Id = 2,
                    Qualification = new List<string> { "bin", "bon" },
                    Phonenumber = new List<string> { "09348999", "99094854" },
                    Education = new List<string> { "Harvardle", "Yalebon" },
                    Experiences = new List<string> { "Coding"},
                    ProfileId = 2

                },
                new Resume
                {
                    Id = 3,
                    Qualification = new List<string> { "binguruskus", "sibongus" },
                    Phonenumber = new List<string> { "66609348", "666094854" },
                    Education = new List<string> { "FakeHarvard", "RealYale" },
                    Experiences = new List<string> { "Bruh" },
                    ProfileId = 3

                }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "MIB",
                    Description = "JAVA project",
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }
                ,
                new Project
                {
                    Id = 2,
                    Title = "Hattmakaren",
                    Description = "SCRUM Project",
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }
                );

			modelBuilder.Entity<Message>()
				.HasOne(msg => msg.Sender)
				.WithMany(prof => prof.SentMessages)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Message>()
				.HasOne(msg => msg.Reciever)
				.WithMany(prof => prof.RecievedMessages)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Message>().HasData(
				new Message
				{
					Id = 1,
					Content = "Tjenare mannen!",
					Created = DateTime.Now,
					IsRead = false,
					SenderId = 1,
					RecieverId = 2
				},
				new Message
				{
					Id = 2,
					Content = "Gott nytt år kompis.",
					Created = DateTime.Now,
					IsRead = false,
					SenderId = 1,
					RecieverId = 3
				},
				new Message
				{
					Id = 3,
					Content = "Jag måste berätta en grej...",
					Created = DateTime.Now,
					IsRead = false,
					SenderId = 2,
					RecieverId = 1
				},
				new Message
				{
					Id = 4,
					Content = "Vem är du? Vem är jag? Levande charader...",
					Created = DateTime.Now,
					IsRead = false,
					SenderId = 3,
					RecieverId = 1
				}
				);

			modelBuilder.Entity<AnonymousMessage>()
				.HasOne(msg => msg.Reciever)
				.WithMany(pr => pr.RecievedAnonymousMessages)
				.OnDelete(DeleteBehavior.Restrict);
		}
    }
}
