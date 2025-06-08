
using System.ComponentModel.DataAnnotations;


namespace LibraryManagementSystem.DAL.Models
{
    public class BorrowingTransaction
    {
        public int Id { get; set; }

        // Foreign key to Book
        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = default!;
        [Required]

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        [Required]
        public string Status { get; set; } = "Available"; // "Available" or "Borrowed"

        public bool IsReturned => ReturnedDate.HasValue;
    }

}
