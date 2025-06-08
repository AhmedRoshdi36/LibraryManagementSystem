using FluentValidation.AspNetCore;
using LibraryManagement.BLL.AuthorManagement.Validators;
using LibraryManagementSystem.BLL.BookValidator;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.BLL.Services;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace LibraryManagementSystem
{
    public class Program
    {
      
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<AuthorValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();

            builder.Services.AddDbContext<LibraryManagementSystem.DAL.LibraryDbContext>(options =>
                options.UseInMemoryDatabase("LibraryDbContext"));
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBorrowingTransactionService, BorrowingTransactionService>();

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBorrowingTransactionRepository, BorrowingTransactionRepository>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LibraryManagementSystem.DAL.LibraryDbContext>();
                db.Database.EnsureCreated();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=book}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
