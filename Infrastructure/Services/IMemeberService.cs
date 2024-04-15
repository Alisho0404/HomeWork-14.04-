using Domain.DTO_s.BookDto;
using Domain.DTO_s.MemberDto;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IMemeberService
    {
        Task<Response<List<GetMemeberDTO>>> GetMemberAsync();
        Task<Response<GetMemeberDTO>> GetMemberByIDAsync(int id);
        Task<Response<string>> AddMemberAsync(AddMemeberDTO member);
        Task<Response<string>> UpdateMemberAsync(UpdateMemeberDTO member);
        Task<Response<bool>> DeleteMemberAsync(int id);
    }
}
