using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.DTos
{
    public class BorrowBookDto
    {

        public int BookId { get; set; }
        public string BookTitle { get; set; } = default!;
        public DateTime BorrowedDate { get; set; }
       
    }

}
