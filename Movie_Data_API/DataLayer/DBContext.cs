using Microsoft.EntityFrameworkCore;
using Movie_Data_API.DataLayer.Entities;

namespace Movie_Data_API.DataLayer
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Movie_Data; Trusted_Connection = True; ")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(
                    new ServiceCollection()
                    .AddLogging(builder => builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                    .BuildServiceProvider().GetService<ILoggerFactory>()
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Actor_ID = 1,
                    Actor_Name = "Robert",
                    Actor_Lastname = "Downey Jr",
                    Birth_Date = new DateTime(1965, 4, 4)
                },
                new Actor
                {
                    Actor_ID = 2,
                    Actor_Name = "Scarlett",
                    Actor_Lastname = "Johansson",
                    Birth_Date = new DateTime(1984, 11, 22)
                },
                new Actor
                {
                    Actor_ID = 3,
                    Actor_Name = "Denzel",
                    Actor_Lastname = "Washington",
                    Birth_Date = new DateTime(1954, 12, 28)
                },
                new Actor
                {
                    Actor_ID = 4,
                    Actor_Name = "Emma",
                    Actor_Lastname = "Stone",
                    Birth_Date = new DateTime(1988, 11, 6)
                });

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Genre_ID = 1, Genre_Name = "Action" },
                new Genre { Genre_ID = 2, Genre_Name = "Comedy" },
                new Genre { Genre_ID = 3, Genre_Name = "Drama" },
                new Genre { Genre_ID = 4, Genre_Name = "Sci-Fi" },
                new Genre { Genre_ID = 5, Genre_Name = "Horror" },
                new Genre { Genre_ID = 6, Genre_Name = "Romance" },
                new Genre { Genre_ID = 7, Genre_Name = "Thriller" },
                new Genre { Genre_ID = 8, Genre_Name = "Fantasy" },
                new Genre { Genre_ID = 9, Genre_Name = "Animation" },
                new Genre { Genre_ID = 10, Genre_Name = "Adventure" }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Role_ID = 1, Role_Name = "Admin" },
                new Role { Role_ID = 2, Role_Name = "User" }
                );

            modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.User_ID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.Movie_ID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>()
            .HasOne(m => m.User)
            .WithMany(u => u.Movies)
            .HasForeignKey(m => m.User_ID)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
