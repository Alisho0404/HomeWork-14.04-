using Domain.DTO_s.MemberDto;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/member")]
    public class MemberController(IMemeberService memeberService):ControllerBase
    {
        [HttpGet] 
        public async Task<Response<List<GetMemeberDTO>>> GetMemberAsync()
        {
            return await memeberService.GetMemberAsync();
        }

        [HttpGet("{memberId:int}")] 
        public async Task<Response<GetMemeberDTO>> GetMembersByIdAsync(int memberId)
        {
            return await memeberService.GetMemberByIDAsync(memberId);
        }

        [HttpPost]
        public async Task<Response<string>>AddMemberAsync(AddMemeberDTO memeberDTO)
        {
            return await memeberService.AddMemberAsync(memeberDTO);
        }

        [HttpPut]
        public async Task<Response<string>>UpdateMemberAsync(UpdateMemeberDTO memeberDTO)
        {
            return await memeberService.UpdateMemberAsync(memeberDTO);
        }

        [HttpDelete("{memberId:int}")] 
        public async Task<Response<bool>>DeleteMemberAsync(int memberId)
        {
            return await memeberService.DeleteMemberAsync(memberId);
        }
    }
}
