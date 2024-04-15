using Domain.DTO_s.LoanDto;
using Domain.DTO_s.MemberDto;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanController(ILoanService LoanService):ControllerBase
    {
        [HttpGet]
        public async Task<Response<List<GetLoanDTO>>> GeLoanAsync()
        {
            return await LoanService.GetLoansAsync();
        }

        [HttpGet("{LoanId:int}")]
        public async Task<Response<GetLoanDTO>> GeLoansByIdAsync(int LoanId)
        {
            return await LoanService.GetLoanById(LoanId);
        }

        [HttpPost]
        public async Task<Response<string>> AdLoanAsync(AddLoanDTO LoanDTO)
        {
            return await LoanService.AddLoanAsync(LoanDTO);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatLoanAsync(UpdateLoanDTO LoanDTO)
        {
            return await LoanService.UpdateLoanAsync(LoanDTO);
        }

        [HttpDelete("{LoanId:int}")]
        public async Task<Response<bool>> DeletLoanAsync(int LoanId)
        {
            return await LoanService.DeleteLoanAsync(LoanId);
        }
    }
}
