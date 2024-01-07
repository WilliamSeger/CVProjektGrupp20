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
        public DbSet<ParticipatesIn> Participants { get; set; }

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
                },
                new User
                {
                    Id = "1234",
                    UserName = "Admin1",
                    PasswordHash = "1234Abc!"
                },
                new User
                {
                    Id = "12345",
                    UserName = "Admin2",
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
                    Name = "Gustav",
                    ProfilePicturePath = "",
                    Adress = "Väggatan 24",
                    Email = new List<string> { "gustav@hotmail.com", "gustav@företag.se" },
                    IsPrivate = false,
                    UserId = "1234"
                },
                new Profile
                {
                    Id = 3,
                    Name = "Göran",
                    ProfilePicturePath = "",
                    Adress = "Husgatan 2",
                    Email = new List<string> { "oru@yahoo.com", "oru@arbete.com" },
                    IsPrivate = false,
                    UserId = "12345"
                }
                );
            modelBuilder.Entity<Resume>().HasData(
                new Resume
                {
                    Id = 1,
                    Qualification = new List<string> { "ASP NET", "HTML-master" },
                    Phonenumber = new List<string> { "09342128", "091234854" },
                    Education = new List<string> { "Harvard", "Yale" },
                    Experiences = new List<string> { "Professional Gamer"},
                    ProfileId = 1

                },
                new Resume
                {
                    Id = 2,
                    Qualification = new List<string> { "Fullstack" },
                    Phonenumber = new List<string> { "09348999", "99094854" },
                    Education = new List<string> { "KTH", "Yalebon" },
                    Experiences = new List<string> { "Google internship" },
                    ProfileId = 2

                },
                new Resume
                {
                    Id = 3,
                    Qualification = new List<string> { "Fullstack", "ASP NET" },
                    Phonenumber = new List<string> { "123891892", "666094854" },
                    Education = new List<string> { "Harvard", "Örebro Universitet" },
                    Experiences = new List<string> { "Rest runt jorden" },
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
                    Updated = DateTime.Now,
                    ProjectOwnerId = 1
                }
                ,
                new Project
                {
                    Id = 2,
                    Title = "Hattmakaren",
                    Description = "SCRUM Project",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
					ProjectOwnerId = 2
				}
                );

			//Composite primary key for deltagare
			modelBuilder.Entity<ParticipatesIn>()
			.HasKey(pa => new { pa.ProjectId, pa.ProfileId });

			modelBuilder.Entity<ParticipatesIn>()
		    .HasOne(pi => pi.Project)
		    .WithMany(p => p.ParticipatesIn)
		    .OnDelete(DeleteBehavior.Restrict);



			modelBuilder.Entity<ParticipatesIn>()
		    .HasOne(pi => pi.Profile)
		    .WithMany(pr => pr.ParticipatesIn)
		    .OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<ParticipatesIn>().HasData(
		    new ParticipatesIn { ProjectId = 1, ProfileId = 1 },
		    new ParticipatesIn { ProjectId = 2, ProfileId = 2 }
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
