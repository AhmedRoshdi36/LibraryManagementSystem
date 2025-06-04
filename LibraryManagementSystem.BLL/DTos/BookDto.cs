using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.DTos
{
    public class BookDto
    {
        public int Id { get; set; }                  
        public string BookTitle { get; set; } = null!;
        public Genre Genre { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }    
    }

}
