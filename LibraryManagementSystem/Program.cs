using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.BLL.Services;
using LibraryManagementSystem.DAL.DbContext;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LibraryManagementSystem.DAL.LibraryDbContext>(options =>
                options.UseInMemoryDatabase("LibraryDbContext"));
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBorrowingService, BorrowingService>();

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();

          

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LibraryManagementSystem.DAL.LibraryDbContext>();
                db.Database.EnsureCreated(); 
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
