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
            new Book { Id = 1, Title = "Mystery Book", Genre = Genre.Mystery, AuthorId = 1 },
            new Book { Id = 2, Title = "Sci-Fi Journey", Genre = Genre.SciFi, AuthorId = 2 },
            new Book { Id = 3, Title = "The Desert Rose", Genre = Genre.Romance, AuthorId = 3 },
            new Book { Id = 4, Title = "Echoes of War", Genre = Genre.Historical, AuthorId = 4 },
            new Book { Id = 5, Title = "Galaxy Chronicles", Genre = Genre.SciFi, AuthorId = 5 },
            new Book { Id = 6, Title = "The Final Clue", Genre = Genre.Mystery, AuthorId = 6 },
            new Book { Id = 7, Title = "Whispers in the Dark", Genre = Genre.Horror, AuthorId = 7 },
            new Book { Id = 8, Title = "Algorithms for Life", Genre = Genre.NonFiction, AuthorId = 8 },
            new Book { Id = 9, Title = "The Eternal Bond", Genre = Genre.Romance, AuthorId = 9 },
            new Book { Id = 10, Title = "Beyond the Stars", Genre = Genre.SciFi, AuthorId = 10 },
            new Book { Id = 11, Title = "Cairo Secrets", Genre = Genre.Mystery, AuthorId = 1 },
            new Book { Id = 12, Title = "Nile Nightmares", Genre = Genre.Horror, AuthorId = 2 },
            new Book { Id = 13, Title = "Love in Alexandria", Genre = Genre.Romance, AuthorId = 3 },
            new Book { Id = 14, Title = "Redemption Path", Genre = Genre.Drama, AuthorId = 4 },
            new Book { Id = 15, Title = "Secrets of AI", Genre = Genre.NonFiction, AuthorId = 5 }
        );
    }
}

