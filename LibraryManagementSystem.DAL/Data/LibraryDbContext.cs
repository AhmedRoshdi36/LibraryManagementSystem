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
    public DbSet<BorrowingTransaction> BorrowingTransactions { get; set; }

  
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
        Id = 4,
        Title = "Shadows of the Mind",
        Genre = Genre.Drama,
        AuthorId = 4,
        Description = "A deep dive into the mental struggles of a young artist."
    },
    new Book
    {
        Id = 5,
        Title = "Cairo Secrets",
        Genre = Genre.Thriller,
        AuthorId = 5,
        Description = "Hidden conspiracies unravel in the heart of Cairo’s tech scene."
    },
    new Book
    {
        Id = 6,
        Title = "The Nile’s Whisper",
        Genre = Genre.Children,
        AuthorId = 6,
        Description = "An enchanting tale about a child's magical journey along the Nile."
    }
);
        modelBuilder.Entity<BorrowingTransaction>().HasData(
    new BorrowingTransaction
    {
        Id = 11,
        BookId = 4,
        BorrowedDate = new DateTime(2025, 5, 2),
        ReturnedDate = new DateTime(2025, 5, 11)
    },
    new BorrowingTransaction
    {
        Id = 12,
        BookId = 5,
        BorrowedDate = new DateTime(2025, 5, 4),
        ReturnedDate = null
    },
    new BorrowingTransaction
    {
        Id = 13,
        BookId = 6,
        BorrowedDate = new DateTime(2025, 5, 6),
        ReturnedDate = new DateTime(2025, 5, 15)
    },
    new BorrowingTransaction
    {
        Id = 14,
        BookId = 4,
        BorrowedDate = new DateTime(2025, 5, 16),
        ReturnedDate = null
    },
    new BorrowingTransaction
    {
        Id = 15,
        BookId = 5,
        BorrowedDate = new DateTime(2025, 5, 18),
        ReturnedDate = new DateTime(2025, 5, 26)
    },
    new BorrowingTransaction
    {
        Id = 16,
        BookId = 6,
        BorrowedDate = new DateTime(2025, 5, 20),
        ReturnedDate = null
    },
    new BorrowingTransaction
    {
        Id = 17,
        BookId = 4,
        BorrowedDate = new DateTime(2025, 5, 22),
        ReturnedDate = new DateTime(2025, 5, 29)
    },
    new BorrowingTransaction
    {
        Id = 18,
        BookId = 5,
        BorrowedDate = new DateTime(2025, 5, 25),
        ReturnedDate = null
    },
    new BorrowingTransaction
    {
        Id = 19,
        BookId = 6,
        BorrowedDate = new DateTime(2025, 5, 27),
        ReturnedDate = null
    },
    new BorrowingTransaction
    {
        Id = 20,
        BookId = 4,
        BorrowedDate = new DateTime(2025, 5, 30),
        ReturnedDate = null
    }
);





    }
}

