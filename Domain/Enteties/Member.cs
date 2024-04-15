using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Member
    {
        public int Id { get; set; } 
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime MembershipDate { get; set; }
        public List<Loan>? Loans { get; set; }
    }
}
