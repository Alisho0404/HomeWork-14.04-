using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Book
    {
        [Key]
        public int Id { get; set; } 

        public required string Title { get; set; }
        public required string Author { get; set; }
        public DateTime PublishedYear { get; set; }
        public string? Genre { get; set; }
        public List<Loan>? Loans { get; set; } 
    }
}
