using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.DTos;

public class BookTransactionDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public DateTime BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
    public string Status { get; set; } = "Available";
    public bool IsReturned => ReturnedDate.HasValue;
}

