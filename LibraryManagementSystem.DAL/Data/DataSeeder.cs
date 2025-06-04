using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.DbContext
{
    public static class DataSeeder
    {
        public static List<Author> SeedAuthors()
        {
            return [
                new Author
                    {
                            FullName = "Emily Jane xx Brontë",
                            Email = "emily@london.com",
                            Website = "emily.novels.uk"
                        },
                        new Author {
                            FullName = "Mia Mohamed xx Attallah",
                            Email = "mirna@gmail.edu.com"
                        },
                        new Author {
                            FullName= "Emily xx xx Jane",
                            Email= "emily0jane@yahoo.com",
                        },
                        new Author
                        {
                            FullName = "John Michael Smith Doe",
                            Email = "john.doe@example.com",
                            Website = "https://johndoe.com",
                        },
                        new Author
                        {
                            FullName = "Alice Mary Brown Lee",
                            Email = "alice.lee@example.com",
                            Website = "https://alicelee.com",
                        }
                    ];
        }
        public static List<Book> SeedBooks(List<Author> authors)
        {
            Random random = new Random();

            return [
                new Book
                {
                    Title = "Wuthering Heights",
                    Genre = Genre.Adventure,
                    Description = "A tale of passion and revenge set on the Yorkshire moors.",
                    AuthorId = authors[random.Next(authors.Count)].Id,
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Genre = Genre.Romance,
                    Description = "A romantic novel that critiques the British landed gentry at the end of the 18th century.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "The Great Adventure",
                    Genre = Genre.Adventure,
                    Description = "An epic journey through uncharted territories.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "The Poetry of Nature",
                    Genre = Genre.Poetry,
                    Description = "A collection of poems celebrating the beauty of the natural world.",
                    AuthorId = authors[random.Next(authors.Count)].Id,
                },
                new Book
                {
                    Title = "The Mystery of the Lost Treasure",
                    Genre = Genre.Mystery,
                    Description = "A thrilling mystery novel about a treasure hunt.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "Historical Tales",
                    Genre = Genre.History,
                    Description = "A collection of short stories set in various historical periods.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                }
                ];
        }
    }
}
