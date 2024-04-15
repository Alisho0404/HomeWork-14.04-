using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.LoanDto
{
    public class UpdateLoanDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemeberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
