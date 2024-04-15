using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.MemberDto
{
    public class AddMemeberDTO
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
