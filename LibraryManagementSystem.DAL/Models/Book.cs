using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string? Title { get; set; }
        [MaxLength(300, ErrorMessage = "Description must be less than 300")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public List<BookTransaction> bookTransactions { get; set; } = new List<BookTransaction>();
    }
}
