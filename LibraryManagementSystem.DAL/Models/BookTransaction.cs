using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Models
{
    public class BookTransaction
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        [Required(ErrorMessage = "you should choose a book")]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        [Required(ErrorMessage = "Enter the date of borrowing")]
        public DateTime BorrowedDate { get; set; }
        //[ReturningDateAfterBorrowingDateValidation(ErrorMessage = "Returned date cannot be earlier than the borrowed date.")]
        public DateTime? ReturnedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
