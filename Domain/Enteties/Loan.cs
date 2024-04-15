using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemeberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Loan? Loans { get; set; }
        public Book? Book { get; set; }



    }
}
