using LibraryManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.DAL;


public class LibraryDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
        

    }
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookTransaction> BookTransactions { get; set; }

  
         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>()
            .HasIndex(a => a.Email)
            .IsUnique();
        modelBuilder.Entity<Author>()
            .HasIndex(a => a.FullName)
            .IsUnique();

        modelBuilder.Entity<Author>().HasData(
  new Author
  {
      Id = 1,
      FullName = "Omar Fathy Youssef Salem",
      Email = "omar.salem@mail.com",
      Website = "https://omarsalem.com",
      Bio = "Omar is a novelist passionate about futuristic sci-fi and AI ethics."
  },
    new Author
    {
        Id = 2,
        FullName = "Sara Mahmoud Ehab Kamel",
        Email = "sara.kamel@outlook.com",
        Website = "https://sarakamel.net",
        Bio = "Sara writes empowering stories focused on women's lives in the Middle East."
    },
    new Author
    {
        Id = 3,
        FullName = "Mohamed Reda Tamer Helmy",
        Email = "mohamed.helmy@gmail.com",
        Website = "https://mohamedwrites.com",
        Bio = "Mohamed specializes in short stories with unexpected twists."
    },
    new Author
    {
        Id = 4,
        FullName = "Lina Hossam Ashraf Nabil",
        Email = "lina.nabil@yahoo.com",
        Website = "https://linanabil.org",
        Bio = "Lina explores mental health topics through fiction and blogs."
    },
    new Author
    {
        Id = 5,
        FullName = "Yassin Khaled Amr Mostafa",
        Email = "yassin.mostafa@mail.com",
        Website = "https://yassinwrites.me",
        Bio = "Yassin is a tech writer covering AI and blockchain technologies."
    },
    new Author
    {
        Id = 6,
        FullName = "Dina Walid Hazem Lotfy",
        Email = "dina.lotfy@gmail.com",
        Website = "https://dinalotfy.com",
        Bio = "Dina writes children's books inspired by Egyptian folklore."
    }
   
);

        modelBuilder.Entity<Book>().HasData(
             new Book
             {
                 Id = 1,
                 Title = "Mystery Book",
                 Genre = Genre.Mystery,
                 AuthorId = 1,
                 Description = "A detective unravels a complex web of secrets in a quiet town."
             },
    new Book
    {
        Id = 2,
        Title = "Sci-Fi Journey",
        Genre = Genre.SciFi,
        AuthorId = 2,
        Description = "A thrilling voyage through distant galaxies and futuristic technology."
    },
    new Book
    {
        Id = 3,
        Title = "The Desert Rose",
        Genre = Genre.Romance,
        AuthorId = 3,
        Description = "A heartfelt love story blossoming amidst the harsh desert landscape."
    }
        );
    }
}

