using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.DTos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string BookTitle { get; set; } = null!;

        [Required(ErrorMessage = "Genre is required")]
        public Genre Genre { get; set; }

        [MaxLength(300, ErrorMessage = "Max length is 300")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }
    }

}
